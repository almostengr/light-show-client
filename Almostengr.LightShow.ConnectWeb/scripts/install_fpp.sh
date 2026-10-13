#!/bin/bash

sudo cp -p almostengr_lightshow.service /etc/systemd/system/

sudo systemctl daemon-reload

sudo systemctl start almostengr_lightshow.service
