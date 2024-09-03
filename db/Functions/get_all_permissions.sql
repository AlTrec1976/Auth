CREATE OR REPLACE FUNCTION public.get_all_permissions()
 RETURNS TABLE(permissionid int4, permissionname character varying)
 LANGUAGE plpgsql
AS $function$
begin
return query
select
    id 		as permissionid,
    name 	as permissionname
from public.permissions;
end;
$function$;