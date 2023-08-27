CREATE
EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE "categories"
(
    "Id"   UUID PRIMARY KEY UNIQUE DEFAULT uuid_generate_v4(),
    "Name" TEXT NOT NULL
);

CREATE TABLE "tags"
(
    "Id" UUID PRIMARY KEY UNIQUE DEFAULT uuid_generate_v4(),
    "Name" TEXT NOT NULL
);