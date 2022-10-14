# MicroServicesAspNet
1. Đổi địa chỉ ip + port sql manage config
2. Bấm Switch between solutions and available view ở tab solution exploere
3. Double click vào folder view
4. Bấm Add - New File ở folder tổng
5. Tạo dockerfile
6.
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY *****.csproj .

RUN dotnet restore

COPY . .

RUN dotnet publish -c release -o /app


----


FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /app

COPY --from=build /app .

ENTRYPOINT [ "dotnet", "******.dll" ]


7. Vào lại solution
8. Run terminal ở project
9. Bấm lệnh :
docker build -t ***** .
10. Bấm lệnh :
docker run -it -d -rm -p PortTuyChinh(3000):80 -name TenContainer *****
11. Tạo một project Api
12. Tải thư viện ocelot gateway (bản 15 cho .Net5)
13. tạo một json file Ocelot.json
14. 
{
  "ReRoutes": [
    {
      "DownstreamPathTemplate": "/Service1",
      "DownstreamScheme": "http",
      "DownstreamHostAndPorts": [
        {
          "Host": "localhost",
          "Port": 3000
        }
      ],
      "UpstreamPathTemplate": "/apigateway/Service1",
      "UpstreamHttpMethod": [ "GET", "PUT", "POST" ]
    },
    {
      "DownstreamPathTemplate": "/Service2",
      "DownstreamScheme": "http",
      "DownstreamHostAndPorts": [
        {
          "Host": "localhost",
          "Port": 4000
        }
      ],
      "UpstreamPathTemplate": "/apigateway/Service2",
      "UpstreamHttpMethod": [ "GET", "PUT", "POST" ]
    }
  ]
}



chú ý **** là giống nhau
