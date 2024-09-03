CREATE OR REPLACE FUNCTION public.get_role_permissions(IN wrole_id int4)
 RETURNS TABLE(permissionid int4, permissionname character varying)
 LANGUAGE plpgsql
AS $function$
begin
return query
select
    p.id  	as permissionid
     ,p.name as permissionname
from public.roles_permissions ps
         left join permissions p on ps.permissionid = p.id
where ps.roleid = wrole_id;
end;
$function$;