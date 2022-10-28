CREATE SEQUENCE public.book_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1;

ALTER SEQUENCE public.book_id_seq
    OWNER TO postgres;

CREATE TABLE public.books
(
    id integer NOT NULL DEFAULT nextval('book_id_seq'::regclass),
    author TEXT,
    launch_date TIMESTAMP(6) NOT NULL,
    price DECIMAL(65, 2) NOT NULL,
    title TEXT,
    CONSTRAINT book_pkey PRIMARY KEY (id)
)