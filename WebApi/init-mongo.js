use LoggingDatabase;

db.createUser({
    user: "logger",
    pwd: "loggerpw",
    roles: [{ role: "readWrite", db: "LoggingDatabase" }]
});