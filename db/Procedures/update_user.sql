CREATE OR REPLACE PROCEDURE public.update_user(
	userid uuid,
	userlogin character,
	userpassword character,
	username character,
	usersurname character,
    usersuremail character,
    usersurphone character)
    LANGUAGE 'plpgsql'

AS $BODY$
BEGIN
UPDATE users SET login=userlogin, password=userpassword, name=username, surname=usersurname, email=usersuremail, phone=usersurphone WHERE id=userid;
END;
$BODY$;
