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