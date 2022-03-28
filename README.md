# Delivery application

This is a small delivery system backend sample in .NET Core 6 (for now).

## Run the application

 ```
  docker-compose up --build -d
 ``` 
 
ps: Postman collection to test the backend is on `e2e` folder for now.

## Roadmap

- [ ] Authentication and Authorization microservice with IdentityServer4
- [X] Ocelot API Gateway initial setup
- [X] Catalog microservice with MongoDB as database
- [X] Basket microservice with Redis as database
- [X] Home Page Aggregator
- [ ] Establishment microservice with PostgreSQL as database
- [ ] Users microservice with PostgreSQL as database
- [ ] Hook Establishment microservice and Users microservice with Authentication
- [ ] Create Menu aggregation between Establishment and Catalog microservices
- [ ] Discounts microservice with PostgreSQL as database
- [ ] Orders microservice with PostgreSQL as database and RabbitMQ as messaging
- [ ] Sync Checkout from Basket microservice with Orders microservice via RabbitMQ
- [ ] Add current order with status to Home Page Aggregator
- [ ] Create Wallet microservice with PostgreSQL as database
- [ ] Create Payment microservice with PostgreSQL as database (Including PIX payment)
- [ ] Create Delivery microservice with Redis as database
- [ ] Create Chat with establishment microservice with MongoDB as database
- [ ] Create Frontend application with React for the final user
- [ ] Create Mobile application with React Native for the final user
- [ ] Create a Electron application with React as frontend for the establishment 
- [ ] Create mobile application with React Native for the establishment
- [ ] Create a mobile application with Flutter for the courier (It's not supposed to be the best optimal project, it's to show some different skills)

