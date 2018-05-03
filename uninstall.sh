#!/bin/bash -x

sfctl application delete --application-id NetFrankenDay2018
sfctl application unprovision --application-type-name NetFrankenDay2018Type --application-type-version 1.0.0
sfctl store delete --content-path NetFrankenDay2018
