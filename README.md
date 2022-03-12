# book-review
 
 <!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/OmelianLevkovych/book-review">
    <img src="assets/book-review-logo.png" alt="Logo" width="250" height="200">
  </a>
 
 
**Richard Feynman: What I cannot create, I do not understand.**
# build & run
```powershell
dotnet restore
dotnet build
cd src/BookReview
dotnet run
```


# unit tests
 
## structure
Only one test proj; the reasoning behind this is that I am expecting not to have a complex solution, and for now it should be fine.    
In case I will see that I am getting too messy with tests, I am going to refactor this in the more suitable way.  
## naming convention
In this solution I'll stick to next namming pattern:  
https://enterprisecraftsmanship.com/posts/you-naming-tests-wrong/  
Lets see how it will work out.



# docker
## docker-compose
### issues with ELK stack (elastic & kibana)
you can have limited resourses, execute the following commands in PS:
```powershell
wsl -d docker-desktop
sysctl -w vm.max_map_count=262144
```