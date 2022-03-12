# BookReview
Own implementation of book review app aka goodreads.com.  
Primary language support English and Ukrainian.  

created via CLI:
```sh
dotnet new sln -BookReview
dotnet new webapi -o src/BookReview
dotnet sln add src/BookReview
```

in order to run the app:
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