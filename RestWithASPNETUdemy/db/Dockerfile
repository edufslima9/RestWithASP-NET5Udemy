FROM postgres:15.0-alpine
EXPOSE 5432
COPY ./RestWithASPNETUdemy/db/migrations/ /home/database/
COPY ./RestWithASPNETUdemy/db/dataset/ /home/database/
COPY ./RestWithASPNETUdemy/ci/init_database.sh /docker-entrypoint-initdb.d/init_database.sh