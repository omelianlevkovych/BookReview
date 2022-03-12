# book-review
 
 <!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/OmelianLevkovych/book-review">
    <img src="assets/logo.png" alt="Logo" width="180" height="180">
  </a>
 
# build & run
```sh
dotnet restore
dotnet build
cd src/BookReview
dotnet run
```


# unit tests
## structure
I have diceded to create only one test proj and avoid going the general way (test proj per proj, MyApp - MyApp.Tests).  
The reasoning behind this is I am expecting not having too complex solution and for now it feels like it can work out.  
In case I will see that I am getting too messy with tests, I am going to refactor this in the more suitable approach.
## naming convention
In this solution I tried to try out new and stick to this namming pattern:
https://enterprisecraftsmanship.com/posts/you-naming-tests-wrong/  
Lets see how it will work out.
