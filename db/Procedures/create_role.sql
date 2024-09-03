CREATE OR REPLACE PROCEDURE public.create_role(IN rolename character varying,  OUT roleid int4)
 LANGUAGE plpgsql
AS $procedure$
BEGIN
INSERT INTO public.roles (name)
VALUES (rolename)
    RETURNING id INTO roleid;
END;
$procedure$;