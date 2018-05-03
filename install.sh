#!/bin/bash
DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

appPkg="$DIR/NetFrankenDay2018/pkg"

WebServiceManifestlocation="$appPkg/NetFrankenDay2018/MenuCardServicePkg"
WebServiceManifestlocationLinux="$WebServiceManifestlocation/ServiceManifest.Linux.xml"
WebServiceManifestlocation="$WebServiceManifestlocation/ServiceManifest.xml"
cp $WebServiceManifestlocationLinux $WebServiceManifestlocation 

StatefulServiceManifestlocation="$appPkg/NetFrankenDay2018/GatewayServicePkg"
StatefulServiceManifestlocationLinux="$StatefulServiceManifestlocation/ServiceManifest.Linux.xml"
StatefulServiceManifestlocation="$StatefulServiceManifestlocation/ServiceManifest.xml"

cp $StatefulServiceManifestlocationLinux $StatefulServiceManifestlocation
cp dotnet-include.sh ./NetFrankenDay2018/pkg/NetFrankenDay2018/MenuCardServicePkg/Code/
cp dotnet-include.sh ./NetFrankenDay2018/pkg/NetFrankenDay2018/GatewayServicePkg/Code
cd $DIR/NetFrankenDay2018/pkg/
sfctl application upload --path NetFrankenDay2018 --show-progress
sfctl application provision --application-type-build-path NetFrankenDay2018
sfctl application create --app-name fabric:/NetFrankenDay2018 --app-type NetFrankenDay2018Type --app-version 1.0.0
cd -
