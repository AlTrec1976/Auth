CREATE OR REPLACE FUNCTION public.get_all_roles()
 RETURNS TABLE(roleid int4, rolename character varying)
 LANGUAGE plpgsql
AS $function$
begin
return query
select
    id 		as roleid,
    name 	as rolename
from public.roles;
end;
$function$;