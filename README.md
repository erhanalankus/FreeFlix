FreeFlix

A Solution that contains multiple modules where-in each of the modules implements a variation of Clean / Onion Architecture.
It mimics Microservices yet keeps the simplicity and goodness of Monoliths.

Modular Monolith Architecture is a software design in which a monolith is made better and modular with importance to re-use components/modules. It’s often quite easy to transition from a Monolith Architecture to Modular Monolith.

Here is an illustration:
![Diagram](readme-images/mm-diagram.webp)

The main idea here is to build a better Monolith Solution.

- API / Host – A very thin Rest API / Host Application that is responsible for registering the controllers/services of other modules into the service container.
- Modules – A logical block of the business unit. For example, Sales. Everything that is related to Sales can be found here. We will walk through the definition of a module in the next section.
- Shared Infrastructure – Application-Specific Interfaces and implementations are found here for other modules to consume. This includes Middlewares, Data Access providers, and so on.
- Finally a Database. Note that you have the flexibility to use multiple databases, i.e one database per module.But it ultimately depends on how you would want to design your application.

You can see that there is not much deviation from a standard Monolith implementation. The basic recipe is to Split your Application into multiple smaller applications/modules and make them follow clean architecture principles.

Check the comments on top of the .csproj files for the purposes of the projects.

Read more about this pattern on:
[https://codewithmukesh.com/blog/modular-architecture-in-aspnet-core/](https://codewithmukesh.com/blog/modular-architecture-in-aspnet-core/)