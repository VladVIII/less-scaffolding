**Welcome to Less scaffolding project!**

*******
As the name proposes, deliverables from this project are able to scaffold relatively complex Less project folder structure based on the specified input.

Less scaffolding took a path of OpenAPI specification. 
That means that input of the executable file is OpenAPI specification document.

**As of date 09/11/2023:**
- executable is able to process OpenAPI specification compliant documents which are provided either as file or via URL 
- it is possible to specify output folder; if it is not specified, the default one is {{currentFolder}}/Less
*******

*******
**Building/publishing:**

Less scaffolding is a traditional .NET Core/C# application.
It can be published by using Visual Studio or using dotnet publish command (these are prity much the same except that VS gives us fancier overview)

*******
**Examples:**

Assuming that we managed to create executable file (LessScaffolding.Execute) usage is straightforward. 

LessScaffolding.Execute C:\Sample.yaml C:\FolderToPutLessStructureInside 
-> given that Sample.yaml contains valid OpenApi specification it will be processed and results will be stored into C:\FolderToPutLessStructureInside folder   

LessScaffolding.Execute C:\Sample.yaml
-> given that Sample.yaml contains valid OpenApi specification it will be processed and results will be stored into C:\Less folder   

LessScaffolding.Execute https://petstore.swagger.io/v2/swagger.json C:\FolderToPutLessStructureInside
-> given that address https://petstore.swagger.io/v2/swagger.json contains valid OpenApi specification it will be processed and results will be stored into C:\FolderToPutLessStructureInside folder   

LessScaffolding.Execute C:\Sample.yaml C:\FolderToPutLessStructureInside
-> given that address https://petstore.swagger.io/v2/swagger.json contains valid OpenApi specification it will be processed and results will be stored into C:\Less folder   

*******
**Resources to check:**
- https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-publish
- https://learn.microsoft.com/en-us/dotnet/core/tutorials/publishing-with-visual-studio
- https://swagger.io/ -> Swagger official website
- https://www.openapis.org/ -> OpenAPI initiative website
- https://chuva.io/ -> Chuva official website
- https://github.com/chuva-io -> git repo of Less framework

