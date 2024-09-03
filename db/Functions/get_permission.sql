CREATE OR REPLACE FUNCTION public.get_permission(pid uuid)
 RETURNS TABLE(prid integer)
 LANGUAGE plpgsql
AS $function$
BEGIN
RETURN QUERY SELECT pr.id
	FROM users_roles u
	LEFT JOIN roles r ON u.role_id = r.id
	LEFT JOIN roles_permissions rp ON r.id=rp.roleid
	LEFT JOIN permissions pr ON rp.permissionid=pr.id
	WHERE u.user_id = pid;
END;
$function$
;