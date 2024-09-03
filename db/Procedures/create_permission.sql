CREATE OR REPLACE PROCEDURE public.create_permission(IN permissionname character varying,  OUT permissionid int4)
 LANGUAGE plpgsql
AS $procedure$
BEGIN
INSERT INTO public.permissions (name)
VALUES (lower(permissionname))
    RETURNING id INTO permissionid;
END;
$procedure$;