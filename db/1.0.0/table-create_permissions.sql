DROP TABLE IF EXISTS public.permissions;
CREATE TABLE IF NOT EXISTS public.permissions
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name character varying(120) COLLATE pg_catalog."default",
    CONSTRAINT "permission_id_PK" PRIMARY KEY (id)
)

TABLESPACE pg_default;

INSERT INTO public.permissions(name) VALUES ('read');
INSERT INTO public.permissions(name) VALUES ('create');
INSERT INTO public.permissions(name) VALUES ('update');
INSERT INTO public.permissions(name) VALUES ('delete');
INSERT INTO public.permissions(name) VALUES ('sysadmin');
INSERT INTO public.permissions(name) VALUES ('admin');
INSERT INTO public.permissions(name) VALUES ('user');

