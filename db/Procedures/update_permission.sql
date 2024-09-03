CREATE OR REPLACE PROCEDURE public.update_permission(IN permissionid int4, IN permissionname character  varying)
 LANGUAGE plpgsql
AS $procedure$
BEGIN
UPDATE permissions SET name=lower(permissionname) WHERE id=permissionid;
END;
$procedure$
;