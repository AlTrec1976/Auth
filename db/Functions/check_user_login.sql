CREATE OR REPLACE FUNCTION public.check_user_login(
	userlogin character)
    RETURNS SETOF users
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
RETURN QUERY SELECT * FROM users WHERE login=userlogin;
END;
$BODY$;