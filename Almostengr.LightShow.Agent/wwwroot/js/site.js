const modalContenlElement = document.getElementById("modalContent");
const runModeElement = document.getElementById("runModeStatus");
const modalElement = new bootstrap.Modal(document.getElementById("modal"), {
    keyboard: false,
});

async function loadAndShowModalAsync(url) {
    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(response);
        }

        modalContenlElement.innerHTML = response.body;
        modalElement.show();
    }
    catch (error) {
        alert("Unable to display form.");
        console.error(error.message);
    }
}

function addModalListeners() {
    const modalLinks = document.getElementsByClassName("modalLink");

    modalLinks.forEach(link => {
        addEventListener("click", async function () {
            const linkUrl = link.getAttribute("data-url");
            await loadAndShowModalAsync(linkUrl);
        });
    });
}

async function refreshRunModeStatus() {
    try {
        const response = await fetch("/home/runmode");
        if (!response.ok) {
            throw new Error(response);
        }

        runModeElement.innerHTML = response.body;
    }
    catch (error) {
        console.log(error.message);
    }

    setTimeout(refreshRunModeStatus, 3000);
}

async function submitModalAsync(submitButton) {
    const formElement = document.getElementById("modalForm");
    const formMethod = formElement.getAttribute("method");
    const formAction = formElement.getAttribute("action");

    const response = await fetch(
        formAction, {
        method: formMethod
    }
    );

    if (!response.ok) {

    }

    if (response.body === "") {
        window.location.reload();
        return;
    }

    modalContenlElement.innerHTML = response.body;
}

addModalListeners();
refreshRunModeStatus();
