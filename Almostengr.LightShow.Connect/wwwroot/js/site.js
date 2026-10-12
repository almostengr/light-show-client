const modalContentElement = document.getElementById("modalContent");
const runModeElement = document.getElementById("runModeStatus");
const modalCoreElement = document.getElementById("myModal");

const modalElement = new bootstrap.Modal(modalCoreElement, {
    keyboard: false,
    backdrop: 'static',
});

async function loadAndShowModalAsync(url) {
    if (url === null) {
        return;
    }

    if (!url || !modalElement || !modalContentElement) {
        console.error("Modal, modal content, or URL is missing.");
        return;
    }

    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(response);
        }

        modalContentElement.innerHTML = await response.text();
        modalElement.show();
    }
    catch (error) {
        alert("Unable to display form.");
        console.error(error.message);
    }
}

function addModalListeners() {
    document.querySelectorAll(".modalLink")
        .forEach(link => {
            link.addEventListener("click", async function (event) {
                event.preventDefault();
                await loadAndShowModalAsync(link.dataset.url);
            });
        });
}

async function refreshLatestStatus() {
    try {
        const response = await fetch("/home/runmode");
        if (!response.ok) {
            throw new Error(response);
        }

        runModeElement.innerHTML = await response.text();
    }
    catch (error) {
        console.error(error.message);
    }

    setTimeout(refreshLatestStatus, 5000);
}

async function submitModalFormAsync(submitButton) {
    const formElement = modalContentElement.querySelector("form");
    if (!formElement) {
        return;
    }

    const formMethod = formElement.getAttribute("method");
    const formAction = formElement.getAttribute("action");
    const formData = new FormData(formElement);

    try {
        const response = await fetch(
            formAction, {
            method: formMethod,
            body: formData
        });

        if (!response.ok) {
            throw new Error(`HTTP error: ${response.status} ${response.statusText}`);
        }

        const result = await response.text();
        if (result === "" || result === null) {
            window.location.reload();
            return;
        }

        modalContentElement.innerHTML = result;
    }
    catch (error) {
        console.error(error.message);
    }
}

addModalListeners();
refreshLatestStatus();
