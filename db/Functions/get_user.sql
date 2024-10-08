CREATE OR REPLACE FUNCTION public.get_user(
	userid uuid)
    RETURNS SETOF users
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
RETURN QUERY SELECT * FROM users WHERE id=userid;
END;
$BODY$;