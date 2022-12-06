# Nine Test App ![example workflow](https://github.com/thommelutten/Nine-Test-App/actions/workflows/dotnet.yml/badge.svg)
A simple .NET Core MVC Web application used to show how to use GitHub Actions and Azure for Continuous Integration / Continuous Delivery purposes.

## Design
The structure of the Web application uses a simplified version of [Jason Taylors Clean Architecture model](https://github.com/jasontaylordev/CleanArchitecture).

## Getting Started
The project can be build using 
```
dotnet build
```

And tests can be run with 

```
dotnet test
```

And published using
```
dotnet publish -C Release -O *OUTPUT_DIR*
```
