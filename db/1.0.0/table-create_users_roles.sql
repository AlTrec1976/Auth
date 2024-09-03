CREATE TABLE public.users_roles (
                                    user_id uuid NOT NULL,
                                    role_id int4 NOT NULL
);

ALTER TABLE public.users_roles ADD CONSTRAINT users_roles_roles_fk FOREIGN KEY (role_id) REFERENCES public.roles(id);
ALTER TABLE public.users_roles ADD CONSTRAINT users_roles_users_fk FOREIGN KEY (user_id) REFERENCES public.users(id);