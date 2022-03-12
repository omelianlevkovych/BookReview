# the checklist
## general
* onboarding: integration instructions for APIs are documented


## disaster recovery
* disaster recovery (DR): DR plans have been documented and tested
* backups of data occurs regulary (background job once per month)


## deployment
* CI
* CD
* static code analysis (stylecop)

## operations
* logging
* metrics
* tracing


## testing
* unit tests
* integration tests

things to consider:
* test coverage
* e2e or acceptance
* broken tests, mutation tests

## resiliency
* load tests

## security
* authentication/authorization
* secret management


# additional things to take into account
## docker & containers
- deploy docker images using EKS

## setup load balancing