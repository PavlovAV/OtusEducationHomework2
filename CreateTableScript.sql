CREATE TABLE public.user (
    user_id bigint PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 6 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
    first_name varchar(100) NOT NULL,
	last_name varchar(100) NULL
	);
	
CREATE TABLE public.category (
    category_id bigint PRIMARY KEY NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 6 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
    name varchar(100) NOT NULL
	);
	
CREATE TABLE public.announcement (
    announcement_id UUID PRIMARY KEY NOT NULL DEFAULT gen_random_uuid(),
	description varchar(1000) NOT NULL,
	author int NOT NULL REFERENCES public.user (user_id),
	category int NOT NULL REFERENCES category (category_id)
	);
	