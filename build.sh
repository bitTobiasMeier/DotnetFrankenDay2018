#!/bin/bash
DIR=`dirname $0`
source $DIR/dotnet-include.sh 
rm -rf $DIR/NetFrankenDay2018/pkg/NetFrankenDay2018




MenuCardServicePckRoot="$DIR/MenuCardService/PackageRoot/."
MenuCardServicePckRootTarget="$DIR/NetFrankenDay2018/pkg/NetFrankenDay2018/MenuCardServicePkg/"
GatewayServicePckRoot="$DIR/GatewayService/PackageRoot/."
GatewayServicePckRootTarget="$DIR/NetFrankenDay2018/pkg/NetFrankenDay2018/GatewayServicePkg/"
mkdir -p $MenuCardServicePckRootTarget
mkdir -p $GatewayServicePckRootTarget

cp -r $MenuCardServicePckRoot $MenuCardServicePckRootTarget
cp -r $GatewayServicePckRoot $GatewayServicePckRootTarget

WebServiceManifestlocation="$DIR/NetFrankenDay2018/pkg/NetFrankenDay2018"
appManifest="$DIR/NetFrankenDay2018/ApplicationPackageRoot/ApplicationManifest.xml"
cp $appManifest $WebServiceManifestlocation 

cd $DIR/MenuCardService.Interfaces/
dotnet restore -s https://api.nuget.org/v3/index.json
dotnet build
cd -


cd $DIR/MenuCardService/
dotnet restore -s https://api.nuget.org/v3/index.json
dotnet build 
dotnet publish -c Linux -o ../NetFrankenDay2018/pkg/NetFrankenDay2018/MenuCardServicePkg/Code 
cd -


cd $DIR/GatewayService/
dotnet restore -s https://api.nuget.org/v3/index.json
dotnet build 
dotnet publish -c Linux -o ../NetFrankenDay2018/pkg/NetFrankenDay2018/GatewayServicePkg/Code/  
cd -
