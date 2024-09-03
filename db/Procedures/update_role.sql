CREATE OR REPLACE PROCEDURE public.update_role(IN roleid int4, IN rolename character  varying)
 LANGUAGE plpgsql
AS $procedure$
BEGIN
UPDATE roles SET name=rolename WHERE id=roleid;
END;
$procedure$;