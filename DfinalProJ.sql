--
-- PostgreSQL database dump
--

-- Dumped from database version 13.1
-- Dumped by pg_dump version 13.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: sp_add_administrator(text, text, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_add_administrator(first_name1 text, last_name1 text, level1 integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    insert into administrators(first_name,last_name,level)
    values(first_name1,last_name1,level1);
    END;
$$;


ALTER PROCEDURE public.sp_add_administrator(first_name1 text, last_name1 text, level1 integer) OWNER TO postgres;

--
-- Name: sp_add_airlinecompanies(text, bigint, bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_add_airlinecompanies(name1 text, country_id1 bigint, user_id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
    insert into airline_companies(name,country_id,user_id)
    values(name1,country_id1,user_id1);
    END;
$$;


ALTER PROCEDURE public.sp_add_airlinecompanies(name1 text, country_id1 bigint, user_id1 bigint) OWNER TO postgres;

--
-- Name: sp_add_country(text); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_add_country(name1 text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    insert into countries(name)
    values(name1);
    END;
$$;


ALTER PROCEDURE public.sp_add_country(name1 text) OWNER TO postgres;

--
-- Name: sp_add_customers(text, text, text, text, text, bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_add_customers(first_name1 text, last_name1 text, address1 text, phone_no1 text, credit_card_no1 text, user_id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
    insert into customers(first_name,last_name,address,phone_no,credit_card_no,user_id)
    values(first_name1,last_name1,address1,phone_no1,credit_card_no1,user_id1);
    END;
$$;


ALTER PROCEDURE public.sp_add_customers(first_name1 text, last_name1 text, address1 text, phone_no1 text, credit_card_no1 text, user_id1 bigint) OWNER TO postgres;

--
-- Name: sp_add_flights(bigint, bigint, bigint, timestamp without time zone, timestamp without time zone, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_add_flights(airline_company_id1 bigint, origin_country_id1 bigint, destination_country_id1 bigint, departure1 timestamp without time zone, landing1 timestamp without time zone, remaining1 integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    insert into flights(airline_company_id,origin_country_id,destination_country_id,departure_time,landing_time,remaining_tickets)
    values(airline_company_id1,origin_country_id1,destination_country_id1,departure1,landing1,remaining1);
    END;
$$;


ALTER PROCEDURE public.sp_add_flights(airline_company_id1 bigint, origin_country_id1 bigint, destination_country_id1 bigint, departure1 timestamp without time zone, landing1 timestamp without time zone, remaining1 integer) OWNER TO postgres;

--
-- Name: sp_add_ticket(bigint, bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_add_ticket(flight_id1 bigint, customer_id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
    insert into tickets(flight_id, customer_id)
    values(flight_id1,customer_id1);
    END;
$$;


ALTER PROCEDURE public.sp_add_ticket(flight_id1 bigint, customer_id1 bigint) OWNER TO postgres;

--
-- Name: sp_add_users(text, text, text, bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_add_users(username1 text, password1 text, email1 text, user_role1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
    insert into users(username, password, email, user_role)
    values(username1,password1,email1,user_role1);
    END;
$$;


ALTER PROCEDURE public.sp_add_users(username1 text, password1 text, email1 text, user_role1 bigint) OWNER TO postgres;

--
-- Name: sp_get_administrator_by_id(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_administrator_by_id(x bigint) RETURNS TABLE(id bigint, first_name text, last_name text, level integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from administrators a where a.id = x;
    END;
$$;


ALTER FUNCTION public.sp_get_administrator_by_id(x bigint) OWNER TO postgres;

--
-- Name: sp_get_airlinecompanies_by_id(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_airlinecompanies_by_id(x bigint) RETURNS TABLE(id bigint, name text, country_id bigint, user_id bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from airline_companies ac where ac.id = x;
    END;
$$;


ALTER FUNCTION public.sp_get_airlinecompanies_by_id(x bigint) OWNER TO postgres;

--
-- Name: sp_get_all_administrators(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_all_administrators() RETURNS TABLE(id bigint, first_name text, last_name text, level integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from administrators;
    END;
$$;


ALTER FUNCTION public.sp_get_all_administrators() OWNER TO postgres;

--
-- Name: sp_get_all_airlinecomapnies(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_all_airlinecomapnies() RETURNS TABLE(id bigint, name text, country_id bigint, user_id bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from airline_companies;
    END;
$$;


ALTER FUNCTION public.sp_get_all_airlinecomapnies() OWNER TO postgres;

--
-- Name: sp_get_all_countries(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_all_countries() RETURNS TABLE(id bigint, name text)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from countries;
    END;
$$;


ALTER FUNCTION public.sp_get_all_countries() OWNER TO postgres;

--
-- Name: sp_get_all_customers(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_all_customers() RETURNS TABLE(id bigint, first_name text, last_name text, address text, phone_no text, credit_card_no text, user_id bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from customers;
    END;
$$;


ALTER FUNCTION public.sp_get_all_customers() OWNER TO postgres;

--
-- Name: sp_get_all_flights(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_all_flights() RETURNS TABLE(id bigint, airline_company_id bigint, origin_country_id bigint, destination_country_id bigint, departure_time timestamp without time zone, landing_time timestamp without time zone, remaining_tickets integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from flights;
    END;
$$;


ALTER FUNCTION public.sp_get_all_flights() OWNER TO postgres;

--
-- Name: sp_get_all_tickets(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_all_tickets() RETURNS TABLE(id bigint, flight_id bigint, customer_id bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from tickets;
    END;
$$;


ALTER FUNCTION public.sp_get_all_tickets() OWNER TO postgres;

--
-- Name: sp_get_all_users(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_all_users() RETURNS TABLE(id bigint, username text, password text, email text, user_role bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from users;
    END;
$$;


ALTER FUNCTION public.sp_get_all_users() OWNER TO postgres;

--
-- Name: sp_get_country_by_id(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_country_by_id(x bigint) RETURNS TABLE(id bigint, name text)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from countries c where c.id = x;
    END;
$$;


ALTER FUNCTION public.sp_get_country_by_id(x bigint) OWNER TO postgres;

--
-- Name: sp_get_customers_by_id(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_customers_by_id(x bigint) RETURNS TABLE(id bigint, first_name text, last_name text, address text, phone_no text, credit_card_no text, user_id bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from customers c where c.id = x;
    END;
$$;


ALTER FUNCTION public.sp_get_customers_by_id(x bigint) OWNER TO postgres;

--
-- Name: sp_get_flights_by_id(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_flights_by_id(x bigint) RETURNS TABLE(id bigint, airline_company_id bigint, origin_country_id bigint, destination_country_id bigint, departure_time timestamp without time zone, landing_time timestamp without time zone, remaining_tickets integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from flights f where f.id = x;
    END;
$$;


ALTER FUNCTION public.sp_get_flights_by_id(x bigint) OWNER TO postgres;

--
-- Name: sp_get_tickets_by_id(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_tickets_by_id(x bigint) RETURNS TABLE(id bigint, flight_id bigint, customer_id bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from tickets t where t.id = x;
    END;
$$;


ALTER FUNCTION public.sp_get_tickets_by_id(x bigint) OWNER TO postgres;

--
-- Name: sp_get_users_by_id(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_users_by_id(x bigint) RETURNS TABLE(id bigint, username text, password text, email text, user_role bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from users u where u.id = x;
    END;
$$;


ALTER FUNCTION public.sp_get_users_by_id(x bigint) OWNER TO postgres;

--
-- Name: sp_remove_administrator(bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_remove_administrator(id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       delete from administrators where id=id1;
    END;
$$;


ALTER PROCEDURE public.sp_remove_administrator(id1 bigint) OWNER TO postgres;

--
-- Name: sp_remove_airlinecompany(bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_remove_airlinecompany(id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       delete from airline_companies where id=id1;
    END;
$$;


ALTER PROCEDURE public.sp_remove_airlinecompany(id1 bigint) OWNER TO postgres;

--
-- Name: sp_remove_country(bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_remove_country(id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       delete from countries where id=id1;
    END;
$$;


ALTER PROCEDURE public.sp_remove_country(id1 bigint) OWNER TO postgres;

--
-- Name: sp_remove_customers(bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_remove_customers(id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       delete from customers where id=id1;
    END;
$$;


ALTER PROCEDURE public.sp_remove_customers(id1 bigint) OWNER TO postgres;

--
-- Name: sp_remove_flights(bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_remove_flights(id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       delete from flights where id=id1;
    END;
$$;


ALTER PROCEDURE public.sp_remove_flights(id1 bigint) OWNER TO postgres;

--
-- Name: sp_remove_tickets(bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_remove_tickets(id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       delete from tickets where id=id1;
    END;
$$;


ALTER PROCEDURE public.sp_remove_tickets(id1 bigint) OWNER TO postgres;

--
-- Name: sp_remove_users(bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_remove_users(id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       delete from users where id=id1;
    END;
$$;


ALTER PROCEDURE public.sp_remove_users(id1 bigint) OWNER TO postgres;

--
-- Name: sp_update_administrator(bigint, text, text, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_update_administrator(id1 bigint, first_name1 text, last_name1 text, level1 integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
       update administrators set first_name=first_name1,last_name=last_name1,level=level1 where id =id1;
    END;
$$;


ALTER PROCEDURE public.sp_update_administrator(id1 bigint, first_name1 text, last_name1 text, level1 integer) OWNER TO postgres;

--
-- Name: sp_update_airlinecompany(bigint, text, bigint, bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_update_airlinecompany(id1 bigint, name1 text, country_id1 bigint, user_id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       update airline_companies set name=name1,country_id=country_id1,user_id=user_id1 where id =id1;
    END;
$$;


ALTER PROCEDURE public.sp_update_airlinecompany(id1 bigint, name1 text, country_id1 bigint, user_id1 bigint) OWNER TO postgres;

--
-- Name: sp_update_country(bigint, text); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_update_country(id1 bigint, name1 text)
    LANGUAGE plpgsql
    AS $$
BEGIN
       update countries set name =name1 where id =id1;
    END;
$$;


ALTER PROCEDURE public.sp_update_country(id1 bigint, name1 text) OWNER TO postgres;

--
-- Name: sp_update_customers(bigint, text, text, text, text, text, bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_update_customers(id1 bigint, first_name1 text, last_name1 text, address1 text, phone_no1 text, credit_card_no1 text, user_id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       update customers set first_name=first_name1,last_name=last_name1,phone_no=phone_no1,address=address1,credit_card_no=credit_card_no1,user_id=user_id1 where id =id1;
    END;
$$;


ALTER PROCEDURE public.sp_update_customers(id1 bigint, first_name1 text, last_name1 text, address1 text, phone_no1 text, credit_card_no1 text, user_id1 bigint) OWNER TO postgres;

--
-- Name: sp_update_flights(bigint, bigint, bigint, bigint, timestamp without time zone, timestamp without time zone, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_update_flights(id1 bigint, airline_company_id1 bigint, origin_country_id1 bigint, destination_country_id1 bigint, departure1 timestamp without time zone, landing1 timestamp without time zone, remaining1 integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
       update flights set airline_company_id=airline_company_id1,origin_country_id=origin_country_id1,destination_country_id=destination_country_id1,departure_time=departure1,landing_time=landing1,remaining_tickets=remaining1 where id =id1;
    END;
$$;


ALTER PROCEDURE public.sp_update_flights(id1 bigint, airline_company_id1 bigint, origin_country_id1 bigint, destination_country_id1 bigint, departure1 timestamp without time zone, landing1 timestamp without time zone, remaining1 integer) OWNER TO postgres;

--
-- Name: sp_update_tickets(bigint, bigint, bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_update_tickets(id1 bigint, flight_id1 bigint, customer_id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       update tickets set flight_id =flight_id1,customer_id=customer_id1 where id =id1;
    END;
$$;


ALTER PROCEDURE public.sp_update_tickets(id1 bigint, flight_id1 bigint, customer_id1 bigint) OWNER TO postgres;

--
-- Name: sp_update_users(bigint, text, text, text, bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_update_users(id1 bigint, username1 text, password1 text, email1 text, user_role1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       update users set username=username1,password=password1,email=email1,user_role=user_role1 where id =id1;
    END;
$$;


ALTER PROCEDURE public.sp_update_users(id1 bigint, username1 text, password1 text, email1 text, user_role1 bigint) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: administrators; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.administrators (
    id integer NOT NULL,
    first_name text NOT NULL,
    last_name text NOT NULL,
    level integer NOT NULL,
    user_id bigint NOT NULL
);


ALTER TABLE public.administrators OWNER TO postgres;

--
-- Name: administrators_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.administrators_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.administrators_id_seq OWNER TO postgres;

--
-- Name: administrators_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.administrators_id_seq OWNED BY public.administrators.id;


--
-- Name: airline_companies; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.airline_companies (
    id bigint NOT NULL,
    name text,
    country_id integer NOT NULL,
    user_id bigint
);


ALTER TABLE public.airline_companies OWNER TO postgres;

--
-- Name: airline_companies_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.airline_companies_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.airline_companies_id_seq OWNER TO postgres;

--
-- Name: airline_companies_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.airline_companies_id_seq OWNED BY public.airline_companies.id;


--
-- Name: countries; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.countries (
    id bigint NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.countries OWNER TO postgres;

--
-- Name: countries_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.countries_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.countries_id_seq OWNER TO postgres;

--
-- Name: countries_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.countries_id_seq OWNED BY public.countries.id;


--
-- Name: customers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.customers (
    id bigint NOT NULL,
    first_name text NOT NULL,
    last_name text NOT NULL,
    address text NOT NULL,
    phone_no text NOT NULL,
    credit_card_no text,
    user_id bigint NOT NULL
);


ALTER TABLE public.customers OWNER TO postgres;

--
-- Name: customers_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.customers_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.customers_id_seq OWNER TO postgres;

--
-- Name: customers_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.customers_id_seq OWNED BY public.customers.id;


--
-- Name: flights; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.flights (
    id bigint NOT NULL,
    airline_company_id bigint NOT NULL,
    origin_country_id bigint NOT NULL,
    destination_country_id integer NOT NULL,
    departure_time timestamp without time zone NOT NULL,
    landing_time timestamp without time zone NOT NULL,
    remaining_tickets integer NOT NULL
);


ALTER TABLE public.flights OWNER TO postgres;

--
-- Name: flights_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.flights_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.flights_id_seq OWNER TO postgres;

--
-- Name: flights_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.flights_id_seq OWNED BY public.flights.id;


--
-- Name: tickets; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tickets (
    id bigint NOT NULL,
    flight_id bigint NOT NULL,
    customer_id bigint NOT NULL
);


ALTER TABLE public.tickets OWNER TO postgres;

--
-- Name: tickets_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tickets_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tickets_id_seq OWNER TO postgres;

--
-- Name: tickets_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tickets_id_seq OWNED BY public.tickets.id;


--
-- Name: user_roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.user_roles (
    id bigint NOT NULL,
    roles_name text NOT NULL
);


ALTER TABLE public.user_roles OWNER TO postgres;

--
-- Name: user_roles_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.user_roles_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.user_roles_id_seq OWNER TO postgres;

--
-- Name: user_roles_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.user_roles_id_seq OWNED BY public.user_roles.id;


--
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id bigint NOT NULL,
    username text NOT NULL,
    password text NOT NULL,
    email text NOT NULL,
    user_role bigint NOT NULL
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_id_seq OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- Name: administrators id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.administrators ALTER COLUMN id SET DEFAULT nextval('public.administrators_id_seq'::regclass);


--
-- Name: airline_companies id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.airline_companies ALTER COLUMN id SET DEFAULT nextval('public.airline_companies_id_seq'::regclass);


--
-- Name: countries id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.countries ALTER COLUMN id SET DEFAULT nextval('public.countries_id_seq'::regclass);


--
-- Name: customers id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.customers ALTER COLUMN id SET DEFAULT nextval('public.customers_id_seq'::regclass);


--
-- Name: flights id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flights ALTER COLUMN id SET DEFAULT nextval('public.flights_id_seq'::regclass);


--
-- Name: tickets id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tickets ALTER COLUMN id SET DEFAULT nextval('public.tickets_id_seq'::regclass);


--
-- Name: user_roles id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_roles ALTER COLUMN id SET DEFAULT nextval('public.user_roles_id_seq'::regclass);


--
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- Data for Name: administrators; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.administrators (id, first_name, last_name, level, user_id) FROM stdin;
1	Ido	Gal	4	2
2	Daniel	levi	1	1
\.


--
-- Data for Name: airline_companies; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.airline_companies (id, name, country_id, user_id) FROM stdin;
1	El_Al	2	2
2	British_airline	8	4
\.


--
-- Data for Name: countries; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.countries (id, name) FROM stdin;
1	USA
2	Israel
3	Turky
4	India
5	Japan
6	Argentina
7	Spain
8	England
\.


--
-- Data for Name: customers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.customers (id, first_name, last_name, address, phone_no, credit_card_no, user_id) FROM stdin;
1	Kobi	Levi	Kfar-Saba	0523114576	5326-1321-4752-4931	3
2	Menahem	Kaplan	Ramat_Gan	0573114576	5326-1231-4852-4741	4
\.


--
-- Data for Name: flights; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.flights (id, airline_company_id, origin_country_id, destination_country_id, departure_time, landing_time, remaining_tickets) FROM stdin;
1	1	2	1	2021-05-15 20:00:00	2021-05-15 22:00:00	20
2	2	8	7	2021-03-10 16:00:00	2021-03-10 17:15:30	15
\.


--
-- Data for Name: tickets; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tickets (id, flight_id, customer_id) FROM stdin;
1	1	1
2	2	2
\.


--
-- Data for Name: user_roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.user_roles (id, roles_name) FROM stdin;
1	admin
2	Regular_administrator
3	Customer
4	anonymous_user
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (id, username, password, email, user_role) FROM stdin;
1	Danilev	0123456	gmail@gmail.com	1
2	Gid23	01236	gmail2@gmail.com	4
3	Dobbi4	01342336	gmail3@gmail.com	3
4	Menah43	0123442336	gmail4@gmail.com	3
\.


--
-- Name: administrators_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.administrators_id_seq', 3, true);


--
-- Name: airline_companies_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.airline_companies_id_seq', 4, true);


--
-- Name: countries_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.countries_id_seq', 8, true);


--
-- Name: customers_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.customers_id_seq', 14, true);


--
-- Name: flights_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.flights_id_seq', 2, true);


--
-- Name: tickets_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tickets_id_seq', 2, true);


--
-- Name: user_roles_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.user_roles_id_seq', 4, true);


--
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 5, true);


--
-- Name: administrators administrators_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.administrators
    ADD CONSTRAINT administrators_pk PRIMARY KEY (id);


--
-- Name: airline_companies airline_companies_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.airline_companies
    ADD CONSTRAINT airline_companies_pk PRIMARY KEY (id);


--
-- Name: countries countries_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.countries
    ADD CONSTRAINT countries_pk PRIMARY KEY (id);


--
-- Name: customers customers_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.customers
    ADD CONSTRAINT customers_pk PRIMARY KEY (id);


--
-- Name: flights flights_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flights
    ADD CONSTRAINT flights_pk PRIMARY KEY (id);


--
-- Name: tickets tickets_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tickets
    ADD CONSTRAINT tickets_pk PRIMARY KEY (id);


--
-- Name: user_roles user_roles_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_roles
    ADD CONSTRAINT user_roles_pk PRIMARY KEY (id);


--
-- Name: users users_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pk PRIMARY KEY (id);


--
-- Name: administrators_user_id_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX administrators_user_id_uindex ON public.administrators USING btree (user_id);


--
-- Name: airline_companies_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX airline_companies_name_uindex ON public.airline_companies USING btree (name);


--
-- Name: airline_companies_user_id_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX airline_companies_user_id_uindex ON public.airline_companies USING btree (user_id);


--
-- Name: countries_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX countries_name_uindex ON public.countries USING btree (name);


--
-- Name: customers_credit_card_no_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX customers_credit_card_no_uindex ON public.customers USING btree (credit_card_no);


--
-- Name: customers_phone_no_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX customers_phone_no_uindex ON public.customers USING btree (phone_no);


--
-- Name: customers_user_id_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX customers_user_id_uindex ON public.customers USING btree (user_id);


--
-- Name: tickets_flight_id_customer_id_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX tickets_flight_id_customer_id_uindex ON public.tickets USING btree (flight_id, customer_id);


--
-- Name: user_roles_roles_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX user_roles_roles_name_uindex ON public.user_roles USING btree (roles_name);


--
-- Name: users_email_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX users_email_uindex ON public.users USING btree (email);


--
-- Name: users_username_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX users_username_uindex ON public.users USING btree (username);


--
-- Name: administrators administrators_users_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.administrators
    ADD CONSTRAINT administrators_users_id_fk FOREIGN KEY (user_id) REFERENCES public.users(id);


--
-- Name: airline_companies airline_companies_users_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.airline_companies
    ADD CONSTRAINT airline_companies_users_id_fk FOREIGN KEY (user_id) REFERENCES public.users(id);


--
-- Name: customers customers_users_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.customers
    ADD CONSTRAINT customers_users_id_fk FOREIGN KEY (user_id) REFERENCES public.users(id);


--
-- Name: flights flights_airline_companies_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flights
    ADD CONSTRAINT flights_airline_companies_id_fk FOREIGN KEY (airline_company_id) REFERENCES public.airline_companies(id);


--
-- Name: flights flights_countries_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flights
    ADD CONSTRAINT flights_countries_id_fk FOREIGN KEY (origin_country_id) REFERENCES public.countries(id);


--
-- Name: flights flights_countries_id_fk_2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flights
    ADD CONSTRAINT flights_countries_id_fk_2 FOREIGN KEY (destination_country_id) REFERENCES public.countries(id);


--
-- Name: tickets tickets_customers_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tickets
    ADD CONSTRAINT tickets_customers_id_fk FOREIGN KEY (customer_id) REFERENCES public.customers(id);


--
-- Name: tickets tickets_flights_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tickets
    ADD CONSTRAINT tickets_flights_id_fk FOREIGN KEY (flight_id) REFERENCES public.flights(id);


--
-- Name: users users_user_roles_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_user_roles_id_fk FOREIGN KEY (user_role) REFERENCES public.user_roles(id);


--
-- PostgreSQL database dump complete
--

