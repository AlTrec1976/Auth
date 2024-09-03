CREATE OR REPLACE FUNCTION public.get_user_roles(IN userid uuid)
 RETURNS TABLE(roleid int4, rolename character varying)
 LANGUAGE plpgsql
AS $function$
begin
return query
select
    r.id  	as roleid
     ,r.name as rolename
from public.users_roles ur
         left join roles r on ur.role_id = r.id
where ur.user_id = userid;

end;
$function$;