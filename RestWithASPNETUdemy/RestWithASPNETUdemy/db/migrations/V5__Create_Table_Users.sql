CREATE SEQUENCE public.user_id_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 2147483647
    CACHE 1;

ALTER SEQUENCE public.user_id_seq
    OWNER TO postgres;

CREATE TABLE public.users
(
    id integer NOT NULL DEFAULT nextval('user_id_seq'::regclass),
    user_name VARCHAR(50) NOT NULL DEFAULT '0',
    password VARCHAR(130) NOT NULL DEFAULT '0',
    full_name VARCHAR(120) NOT NULL,
    refresh_token VARCHAR(500) NOT NULL DEFAULT '0',
    refresh_token_expiry_time TIMESTAMP NULL DEFAULT NULL,
    CONSTRAINT user_pkey PRIMARY KEY (id),
    UNIQUE(user_name)
)