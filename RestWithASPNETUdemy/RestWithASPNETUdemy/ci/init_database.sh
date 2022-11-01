PGPASSWORD=toor
for i in `find /home/database/ -name "*.sql" | sort -V`; do psql -U postgres -W -d rest_with_asp_net_udemy -a -f < $i; done;