CREATE TABLE public.users (
                              id uuid NOT NULL DEFAULT gen_random_uuid(),
                              login varchar(50) NOT NULL,
                              password varchar(128) NOT NULL,
                              name varchar(50),
                              surname varchar(50),
                              email varchar(50) NOT NULL,
                              phone varchar(15),
                              CONSTRAINT users_pkey PRIMARY KEY (id)
);