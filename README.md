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


chú ý **** là giống nhau
