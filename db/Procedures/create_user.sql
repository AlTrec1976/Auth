CREATE OR REPLACE PROCEDURE public.create_user(IN userlogin character, IN userpassword character, IN username character, IN usersurname character, IN usersuremail character, IN usersurphone character)
 LANGUAGE plpgsql
AS $procedure$
BEGIN
INSERT INTO public.users (login, password, name, surname, email, phone) VALUES (userlogin, userpassword, username, usersurname, usersuremail, usersurphone);
END;
$procedure$;