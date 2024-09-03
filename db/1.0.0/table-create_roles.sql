DROP TABLE IF EXISTS public.roles;

CREATE TABLE IF NOT EXISTS public.roles
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name character varying(120) COLLATE pg_catalog."default",
    CONSTRAINT role_id PRIMARY KEY (id)
)

TABLESPACE pg_default;

INSERT INTO public.roles(name) VALUES ('Системный администратор');
INSERT INTO public.roles(name) VALUES ('Администратор');
INSERT INTO public.roles(name) VALUES ('Пользователь');