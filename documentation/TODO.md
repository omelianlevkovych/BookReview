# overall
app to add reviews for books, register, send notifications and many more domain logic.  

# short term tasks
* mkdir test and cover logic as it growth (use TDD when needed)
* CI to run the tests




# ideas for future
* docker support
* deploy into cloud
* refactor into clean architecture



# notes
## add migration
To add new ef core migration select the api (where the startup and DI) as a startup proj and default proj to src/Domain.  
Than type in CLI:

```sh
add-migration InitialSchema
```

In case you are getting some nasty error try to add -verbose:

```sh
add-migration InitialSchema -verbose
```