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
-- Name: sp_add_administrator(text, text, integer, bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_add_administrator(first_name1 text, last_name1 text, level1 integer, user_id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
    insert into administrators(first_name,last_name,level,user_id)
    values(first_name1,last_name1,level1,user_id1);
    
    END;
$$;


ALTER PROCEDURE public.sp_add_administrator(first_name1 text, last_name1 text, level1 integer, user_id1 bigint) OWNER TO postgres;

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
-- Name: sp_add_airlinecompanies_to_waiting(text, bigint, bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_add_airlinecompanies_to_waiting(name1 text, country_id1 bigint, user_id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
    insert into waiting_airlines(name,country_id,user_id)
    values(name1,country_id1,user_id1);
    END;
$$;


ALTER PROCEDURE public.sp_add_airlinecompanies_to_waiting(name1 text, country_id1 bigint, user_id1 bigint) OWNER TO postgres;

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
-- Name: sp_delete_all_tables(); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_delete_all_tables()
    LANGUAGE plpgsql
    AS $$
    BEGIN
        truncate administrators,airline_companies,customers,users,tickets,tickets_history,flights,flight_history;
        END
    $$;


ALTER PROCEDURE public.sp_delete_all_tables() OWNER TO postgres;

--
-- Name: sp_delete_old_flights(); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_delete_old_flights()
    LANGUAGE plpgsql
    AS $$
    BEGIN
        delete from flights
        using tickets
        where flights.landing_time <= now() - interval '3 hour';

        END
    $$;


ALTER PROCEDURE public.sp_delete_old_flights() OWNER TO postgres;

--
-- Name: sp_delete_old_tickets(); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_delete_old_tickets()
    LANGUAGE plpgsql
    AS $$
    BEGIN
        delete from tickets
        using flights
        where flights.landing_time <= now() - interval '3 hour';

        END
    $$;


ALTER PROCEDURE public.sp_delete_old_tickets() OWNER TO postgres;

--
-- Name: sp_get_administrator_by_id(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_administrator_by_id(x bigint) RETURNS TABLE(id bigint, first_name text, last_name text, level integer, user_id bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
        RETURN QUERY
                    select * from administrators where administrators.id = x;
    END;
$$;


ALTER FUNCTION public.sp_get_administrator_by_id(x bigint) OWNER TO postgres;

--
-- Name: sp_get_administrators_by_username(text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_administrators_by_username(uname text) RETURNS TABLE(id bigint, first_name text, last_name text, level integer, user_id bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select a.id,a.first_name,a.last_name,a.level,a.user_id from administrators a inner join users u on a.user_id = u.id
                    where u.username =uname;
    END
$$;


ALTER FUNCTION public.sp_get_administrators_by_username(uname text) OWNER TO postgres;

--
-- Name: sp_get_airlinecompanies_by_country_id(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_airlinecompanies_by_country_id(country_id_parm bigint) RETURNS TABLE(id bigint, user_id bigint, country_id bigint, name text)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select ac.id,ac.user_id,ac.country_id,ac.name from airline_companies ac inner join countries c on ac.country_id = c.id
                     where c.id=country_id_parm;
    END;
$$;


ALTER FUNCTION public.sp_get_airlinecompanies_by_country_id(country_id_parm bigint) OWNER TO postgres;

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
-- Name: sp_get_airlinecompanies_by_username(text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_airlinecompanies_by_username(uname text) RETURNS TABLE(id bigint, user_id bigint, country_id bigint, name text)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select ac.id,ac.user_id,ac.country_id,ac.name from airline_companies ac inner join users u on ac.user_id = u.id
                    where u.username =uname;
    END;
$$;


ALTER FUNCTION public.sp_get_airlinecompanies_by_username(uname text) OWNER TO postgres;

--
-- Name: sp_get_all_administrators(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_all_administrators() RETURNS TABLE(id bigint, first_name text, last_name text, level integer, user_id bigint)
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
-- Name: sp_get_all_waiting_airlinecomapnies(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_all_waiting_airlinecomapnies() RETURNS TABLE(id bigint, name text, country_id bigint, user_id bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from waiting_airlines;
    END;
$$;


ALTER FUNCTION public.sp_get_all_waiting_airlinecomapnies() OWNER TO postgres;

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
-- Name: sp_get_customers_by_username(text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_customers_by_username(uname text) RETURNS TABLE(id bigint, first_name text, last_name text, address text, phone_no text, credit_card_no text, userid bigint, username text)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select c.id,c.first_name,c.last_name,c.address,c.phone_no,c.credit_card_no,c.user_id,u.username from customers c inner join users u on c.user_id = u.id where
                    u.username =uname;
    END;
$$;


ALTER FUNCTION public.sp_get_customers_by_username(uname text) OWNER TO postgres;

--
-- Name: sp_get_flights_by_airline_id(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_flights_by_airline_id(x bigint) RETURNS TABLE(id bigint, airline_company_id bigint, origin_country_id bigint, destination_country_id bigint, departure_time timestamp without time zone, landing_time timestamp without time zone, remaining_tickets integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from flights f where f.airline_company_id = x;
    END;
$$;


ALTER FUNCTION public.sp_get_flights_by_airline_id(x bigint) OWNER TO postgres;

--
-- Name: sp_get_flights_by_customerid(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_flights_by_customerid(customerid bigint) RETURNS TABLE(id bigint, airline_company_id bigint, origin_country_id bigint, destination_country_id bigint, departure_time timestamp without time zone, landing_time timestamp without time zone, remaining_tickets integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query

     select f.id,f.airline_company_id,f.origin_country_id,f.destination_country_id,f.departure_time,f.landing_time,f.remaining_tickets from flights f inner join tickets t on f.id = t.flight_id
    inner join customers c on t.customer_id = c.id where c.id =customerid;


    END;

$$;


ALTER FUNCTION public.sp_get_flights_by_customerid(customerid bigint) OWNER TO postgres;

--
-- Name: sp_get_flights_by_departure_time(timestamp without time zone); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_flights_by_departure_time(d_time timestamp without time zone) RETURNS TABLE(id bigint, airline_company_id bigint, origin_country_id bigint, destination_country_id bigint, departure_time timestamp without time zone, landing_time timestamp without time zone, remaining_tickets integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from flights f where f.departure_time=d_time;
    END;
$$;


ALTER FUNCTION public.sp_get_flights_by_departure_time(d_time timestamp without time zone) OWNER TO postgres;

--
-- Name: sp_get_flights_by_destination_country(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_flights_by_destination_country(d_country bigint) RETURNS TABLE(id bigint, airline_company_id bigint, origin_country_id bigint, destination_country_id bigint, departure_time timestamp without time zone, landing_time timestamp without time zone, remaining_tickets integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select f.id,f.airline_company_id,f.origin_country_id,f.destination_country_id,f.departure_time,f.landing_time,f.remaining_tickets from flights f inner join countries c on f.destination_country_id = c.id
                    where c.id = d_country;
    END;
$$;


ALTER FUNCTION public.sp_get_flights_by_destination_country(d_country bigint) OWNER TO postgres;

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
-- Name: sp_get_flights_by_landing_time(timestamp without time zone); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_flights_by_landing_time(l_time timestamp without time zone) RETURNS TABLE(id bigint, airline_company_id bigint, origin_country_id bigint, destination_country_id bigint, departure_time timestamp without time zone, landing_time timestamp without time zone, remaining_tickets integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from flights f where f.landing_time=l_time;
    END;
$$;


ALTER FUNCTION public.sp_get_flights_by_landing_time(l_time timestamp without time zone) OWNER TO postgres;

--
-- Name: sp_get_flights_by_origin_country(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_flights_by_origin_country(o_country bigint) RETURNS TABLE(id bigint, airline_company_id bigint, origin_country_id bigint, destination_country_id bigint, departure_time timestamp without time zone, landing_time timestamp without time zone, remaining_tickets integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select f.id,f.airline_company_id,f.origin_country_id,f.destination_country_id,f.departure_time,
                           f.landing_time,f.remaining_tickets from flights f inner join countries c on f.origin_country_id = c.id
                    where c.id = o_country;
    END;
$$;


ALTER FUNCTION public.sp_get_flights_by_origin_country(o_country bigint) OWNER TO postgres;

--
-- Name: sp_get_flights_by_parameters(timestamp without time zone, timestamp without time zone, bigint, bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_flights_by_parameters(d_time timestamp without time zone, l_time timestamp without time zone, d_country bigint, o_country bigint) RETURNS TABLE(id bigint, airline_company_id bigint, origin_country_id bigint, destination_country_id bigint, departure_time timestamp without time zone, landing_time timestamp without time zone, remaining_tickets integer)
    LANGUAGE plpgsql
    AS $$
BEGIN

return query
select * from flights f where f.departure_time=d_time and f.landing_time=l_time and  f.destination_country_id= d_country and f.origin_country_id=o_country;

    END;
$$;


ALTER FUNCTION public.sp_get_flights_by_parameters(d_time timestamp without time zone, l_time timestamp without time zone, d_country bigint, o_country bigint) OWNER TO postgres;

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
-- Name: sp_get_users_by_username(text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_users_by_username(username1 text) RETURNS TABLE(id bigint, username text, password text, email text, user_role bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from users u where u.username= username1;
    END;
$$;


ALTER FUNCTION public.sp_get_users_by_username(username1 text) OWNER TO postgres;

--
-- Name: sp_get_waiting_airlinecompanies_by_country_id(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_waiting_airlinecompanies_by_country_id(country_id_parm bigint) RETURNS TABLE(id bigint, user_id bigint, country_id bigint, name text)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select ac.id,ac.user_id,ac.country_id,ac.name from waiting_airlines ac inner join countries c on ac.country_id = c.id
                     where c.id=country_id_parm;
    END;
$$;


ALTER FUNCTION public.sp_get_waiting_airlinecompanies_by_country_id(country_id_parm bigint) OWNER TO postgres;

--
-- Name: sp_get_waiting_airlinecompanies_by_id(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_waiting_airlinecompanies_by_id(x bigint) RETURNS TABLE(id bigint, name text, country_id bigint, user_id bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select * from waiting_airlines ac where ac.id = x;
    END;
$$;


ALTER FUNCTION public.sp_get_waiting_airlinecompanies_by_id(x bigint) OWNER TO postgres;

--
-- Name: sp_get_waiting_airlinecompanies_by_username(text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sp_get_waiting_airlinecompanies_by_username(uname text) RETURNS TABLE(id bigint, user_id bigint, country_id bigint, name text)
    LANGUAGE plpgsql
    AS $$
BEGIN
        return query
                    select ac.id,ac.user_id,ac.country_id,ac.name from waiting_airlines ac inner join users u on ac.user_id = u.id
                    where u.username =uname;
    END;
$$;


ALTER FUNCTION public.sp_get_waiting_airlinecompanies_by_username(uname text) OWNER TO postgres;

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
-- Name: sp_remove_waiting_airlinecompany(bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_remove_waiting_airlinecompany(id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       delete from waiting_airlines where id=id1;
    END;
$$;


ALTER PROCEDURE public.sp_remove_waiting_airlinecompany(id1 bigint) OWNER TO postgres;

--
-- Name: sp_update_administrator(bigint, text, text, integer, bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_update_administrator(id1 bigint, first_name1 text, last_name1 text, level1 integer, user_id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       update administrators set first_name=first_name1,last_name=last_name1,level=level1,user_id=user_id1 where id =id1;
    END;
$$;


ALTER PROCEDURE public.sp_update_administrator(id1 bigint, first_name1 text, last_name1 text, level1 integer, user_id1 bigint) OWNER TO postgres;

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
       update flights set  airline_company_id=airline_company_id1,origin_country_id=origin_country_id1,destination_country_id=destination_country_id1,departure_time=departure1,landing_time=landing1,remaining_tickets=remaining1 where id =id1;
    END;
$$;


ALTER PROCEDURE public.sp_update_flights(id1 bigint, airline_company_id1 bigint, origin_country_id1 bigint, destination_country_id1 bigint, departure1 timestamp without time zone, landing1 timestamp without time zone, remaining1 integer) OWNER TO postgres;

--
-- Name: sp_update_flights_history(); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_update_flights_history()
    LANGUAGE plpgsql
    AS $$
    BEGIN
        update flight_history
        set id = f.id,
        airline_company_id= f.airline_company_id,
        origin_country_id=f.origin_country_id,
        destination_country_id= f.destination_country_id,
        departure_time=f.departure_time,
        landing_time =f.landing_time,
        remaining_tickets=f.remaining_tickets
        
        from flights f join tickets t on f.id = t.flight_id
            where f.landing_time<= now() - interval '3 hour' ;
        END
    $$;


ALTER PROCEDURE public.sp_update_flights_history() OWNER TO postgres;

--
-- Name: sp_update_ticket_history(); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_update_ticket_history()
    LANGUAGE plpgsql
    AS $$
    BEGIN
        update tickets_history
        set id = tickets.id,
        flight_id= tickets.flight_id,
        customer_id=tickets.customer_id
        from tickets join flights f on tickets.flight_id = f.id
            where f.landing_time<= now() - interval '3 hour' ;
        END
    $$;


ALTER PROCEDURE public.sp_update_ticket_history() OWNER TO postgres;

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

--
-- Name: sp_update_waiting_airlinecompany(bigint, text, bigint, bigint); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.sp_update_waiting_airlinecompany(id1 bigint, name1 text, country_id1 bigint, user_id1 bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
       update waiting_airlines set name=name1,country_id=country_id1,user_id=user_id1 where id =id1;
    END;
$$;


ALTER PROCEDURE public.sp_update_waiting_airlinecompany(id1 bigint, name1 text, country_id1 bigint, user_id1 bigint) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: administrators; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.administrators (
    id bigint NOT NULL,
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
    country_id bigint NOT NULL,
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
-- Name: flight_history; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.flight_history (
    id bigint NOT NULL,
    airline_company_id bigint,
    origin_country_id bigint,
    destination_country_id bigint,
    departure_time timestamp without time zone,
    landing_time timestamp without time zone,
    remaining_tickets integer
);


ALTER TABLE public.flight_history OWNER TO postgres;

--
-- Name: flights; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.flights (
    id bigint NOT NULL,
    airline_company_id bigint NOT NULL,
    origin_country_id bigint NOT NULL,
    destination_country_id bigint NOT NULL,
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
-- Name: tickets_history; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tickets_history (
    id bigint NOT NULL,
    flight_id bigint,
    customer_id bigint
);


ALTER TABLE public.tickets_history OWNER TO postgres;

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
-- Name: waiting_airlines; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.waiting_airlines (
    id bigint NOT NULL,
    name text,
    country_id bigint NOT NULL,
    user_id bigint
);


ALTER TABLE public.waiting_airlines OWNER TO postgres;

--
-- Name: waiting_airlines_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.waiting_airlines_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.waiting_airlines_id_seq OWNER TO postgres;

--
-- Name: waiting_airlines_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.waiting_airlines_id_seq OWNED BY public.waiting_airlines.id;


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
-- Name: waiting_airlines id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.waiting_airlines ALTER COLUMN id SET DEFAULT nextval('public.waiting_airlines_id_seq'::regclass);


--
-- Data for Name: administrators; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.administrators (id, first_name, last_name, level, user_id) FROM stdin;
1	ido	gal	3	2
7	itay	Levi	2	3
12	asdadasdada	asdadasda	1	62
15	DammDanielTest	LastTestONthisprt	3	65
2	Daniel	levi	3	1
\.


--
-- Data for Name: airline_companies; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.airline_companies (id, name, country_id, user_id) FROM stdin;
3	XLairways	8	57
1	El_Al	2	59
9	testa123333	247	48
2	British_airline	8	52
10	TestingCompany10000008888	150	61
\.


--
-- Data for Name: countries; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.countries (id, name) FROM stdin;
1	USA
2	Israel
4	India
5	Japan
6	Argentina
7	Spain
8	England
9	Afghanistan
10	Aland Islands
11	Albania
12	Algeria
13	American Samoa
14	Andorra
15	Angola
16	Anguilla
17	Antarctica
18	Antigua and Barbuda
19	Armenia
20	Aruba
21	Australia
22	Austria
23	Azerbaijan
24	Bahamas
25	Bahrain
26	Bangladesh
27	Barbados
28	Belarus
29	Belgium
30	Belize
31	Benin
32	Bermuda
33	Bhutan
34	Bolivia
35	Bonaire
36	Bosnia and Herzegovina
37	Botswana
38	Bouvet Island
39	Brazil
40	British Indian Ocean Territory
41	Brunei
42	Bulgaria
43	Burkina Faso
44	Burundi
45	Cambodia
46	Cameroon
47	Canada
48	Cape Verde
49	Cayman Islands
50	Central African Republic
51	Chad
52	Chile
53	China
54	Christmas Island
55	Cocos (Keeling) Islands
56	Colombia
57	Comoros
58	Congo
59	Cook Islands
60	Costa Rica
61	Ivory Coast
62	Croatia
63	Cuba
64	Curacao
65	Cyprus
66	Czech Republic
67	Democratic Republic of the Congo
68	Denmark
69	Djibouti
70	Dominica
71	Dominican Republic
72	Ecuador
73	Egypt
74	El Salvador
75	Equatorial Guinea
76	Eritrea
77	Estonia
78	Ethiopia
79	Falkland Islands (Malvinas)
80	Faroe Islands
81	Fiji
82	Finland
83	France
84	French Guiana
85	French Polynesia
86	French Southern Territories
87	Gabon
88	Gambia
89	Georgia
90	Germany
91	Ghana
92	Gibraltar
93	Greece
94	Greenland
95	Grenada
96	Guadaloupe
97	Guam
98	Guatemala
99	Guernsey
100	Guinea
101	Guinea-Bissau
102	Guyan
103	Haiti
104	Heard Island and McDonald Islands
105	Honduras
106	Hong Kong
107	Hungary
108	Iceland
109	Indonesia
110	Iran
111	Iraq
112	Ireland
113	Isle of Man
114	Italy
115	Jamaica
116	Jersey
117	Jordan
118	Kazakhstan
119	Kenya
120	Kiribati
121	Kosovo
122	Kuwait
123	Kyrgyzstan
124	Laos
125	Latvia
126	Lebanon
127	Lesotho
128	Liberia
129	Libya
130	Liechtenstein
131	Lithuania
132	Luxembourg
133	Macao
134	Macedonia
135	Madagascar
136	Malawi
137	Malaysia
138	Maldives
139	Mali
140	Malta
141	Marshall Islands
142	Martinique
143	Mauritania
144	Mauritius
145	Mayotte
146	Mexico
147	Micronesia
148	Moldava
149	Monaco
150	Mongolia
151	Montenegro
152	Montserrat
153	Morocco
154	Mozambique
155	Myanmar (Burma)
156	Namibia
157	Nauru
158	Nepal
159	Netherlands
160	New Caledonia
161	New Zealand
162	Nicaragua
163	Niger
164	Nigeria
165	Niue
3	Turkey
166	Norfolk Island
167	North Korea
168	Northern Mariana Islands
169	Norway
170	Oman
171	Pakistan
172	Palau
173	Panama
174	Papua New Guinea
175	Paraguay
176	Peru
177	Phillipines
178	Pitcairn
179	Poland
180	Portugal
181	Puerto Rico
182	Qatar
183	Reunion
184	Romania
185	Russia
186	Rwanda
187	Saint Barthelemy
188	Saint Helena
189	Saint Kitts and Nevis
190	Saint Lucia
191	Saint Martin
192	Saint Pierre and Miquelon
193	Saint Vincent and the Grenadines
194	Samoa
195	San Marino
196	Sao Tome and Principe
197	Saudi Arabia
198	Senegal
199	Serbia
200	Seychelles
201	Sierra Leone
202	Singapore
203	Sint Maarten
204	Slovakia
205	Slovenia
206	Solomon Islands
207	Somalia
208	South Africa
209	South Georgia and the South Sandwich Islands
210	South Korea
211	South Sudan
212	Sri Lanka
213	Sudan
214	Suriname
215	Svalbard and Jan Mayen
216	Swaziland
217	Sweden
218	Switzerland
219	Syria
220	Taiwan
221	Tajikistan
222	Tanzania
223	Thailand
224	Timor-Leste (East Timor)
225	Togo
226	Tokelau
227	Tonga
228	Trinidad and Tobago
229	Tunisia
230	Turkmenistan
231	Turks and Caicos Islands
232	Tuvalu
233	Uganda
234	Ukraine
235	United Arab Emirates
236	United States Minor Outlying Islands
237	Uruguay
238	Uzbekistan
239	Vanuatu
240	Vatican City
241	Venezuela
242	Vietnam
243	Virgin Islands
244	Wallis and Futuna
245	Western Sahara
246	Yemen
247	Zambia
248	Zimbabwe
\.


--
-- Data for Name: customers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.customers (id, first_name, last_name, address, phone_no, credit_card_no, user_id) FROM stdin;
2	Menahem	Kaplan	Ramat_Gan	0573114576	5326-1231-4852-4741	4
16	cusw	tomerw	ytle3	03-234234234	23131313	6
22	sad	dsad	ddd-Sdfdaba	sdadad	1233-43434-4544-qqqq	18
35	 DDDDD	KKKKK	JJJJJJ	5555444444	0221545488798895	34
52	234234234	423423432	4343242	5353455686787854645	42342342342	51
1	Timon	Pumba	Kfar-Saba	0523114576	1111-1111-1111-1111	3
\.


--
-- Data for Name: flight_history; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.flight_history (id, airline_company_id, origin_country_id, destination_country_id, departure_time, landing_time, remaining_tickets) FROM stdin;
\.


--
-- Data for Name: flights; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.flights (id, airline_company_id, origin_country_id, destination_country_id, departure_time, landing_time, remaining_tickets) FROM stdin;
1	1	2	1	2021-05-15 00:00:00	2021-05-15 00:00:00	20
7	3	3	6	2021-04-11 00:00:00	2021-04-26 00:00:00	10
9	3	3	6	2021-04-11 00:00:00	2021-04-26 00:00:00	10
3	2	32	67	2021-11-19 20:00:00	2022-10-28 20:04:00	543
11	2	130	2	2021-11-24 20:00:00	2022-10-10 20:00:00	7132
12	2	3	73	2021-10-22 16:09:00	2021-10-23 21:09:00	50
\.


--
-- Data for Name: tickets; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tickets (id, flight_id, customer_id) FROM stdin;
24	1	1
\.


--
-- Data for Name: tickets_history; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tickets_history (id, flight_id, customer_id) FROM stdin;
\.


--
-- Data for Name: user_roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.user_roles (id, roles_name) FROM stdin;
1	admin
3	Customer
2	airline company
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (id, username, password, email, user_role) FROM stdin;
1	Danilev	0123456	gmail@gmail.com	1
4	Menah43	0123442336	gmail4@gmail.com	3
2	Gid23	01236	gmail2@gmail.com	3
6	admin1	pass	something@gmail.com	1
18	danil	asdasd	asda@fadssa	3
34	 AAAAAASSS	AAAASSSDDD	AAAAAAAASSS@@sADASDASDAS	3
36		rrrrrrrrr	sssdada@gmail.com	3
38	test1111	test	testtt@gass.co.il	3
40	TestLAST	aaaaassss	Emailgmail@gmail.com	3
41	TESTING2222	123123123	123TEST123@GMAIL.COM	3
42	LASTTESTPLZ	wreteret	ssdddaa@gmailTest.test	3
43	usertest352plz	lasttest	testestestest@gmail.com	3
44	123123test	danieboy	1234444@gmial.ctest.co.il	3
45	ddddd22211aa	asdasdasd	12323123@gmaaaaai.com	3
46	asdqqqweeee	qqqqaasssdd	qqqweqwewqewe@@gmail.cccc	3
47	wqewewqeqweqwe	qweqeqweqe	qweqweqweqweq@gmail.com	3
49	TESTITEST21	TESTETSTESTESTEST	TESTTTTTEST@GNAU.CIN	3
51	424324234234234	3242343242424	32423434546456563424	3
53	sadasdasdadassdasdas	awqeqeqwewqewqeqwe	wqeqweqweqweqweqweqwe	2
57	TEstingCompany123333123	32131320002321	testingCompany123@gmail.com	2
62	adadasdasdasd	asdadasdasdad	adasdasdasd	1
65	1123testingplayer		123213@g12312@.co-test.com	1
61	TEstingCompany123333100000008	123456789	dadadasd12312312@gmial.test.company.il.com	2
3	Dobbi4	1234567	gmail3@gmail.com	3
59	TEstingCompany1008	1234567	Testing1008@gmail.com	2
48	airline2223	123456789	1111@gmial.airline.com	2
52	TEstingCompany123333	123456789	testingCompany1333@gmail.com	2
\.


--
-- Data for Name: waiting_airlines; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.waiting_airlines (id, name, country_id, user_id) FROM stdin;
\.


--
-- Name: administrators_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.administrators_id_seq', 15, true);


--
-- Name: airline_companies_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.airline_companies_id_seq', 11, true);


--
-- Name: countries_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.countries_id_seq', 8, true);


--
-- Name: customers_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.customers_id_seq', 52, true);


--
-- Name: flights_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.flights_id_seq', 12, true);


--
-- Name: tickets_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tickets_id_seq', 26, true);


--
-- Name: user_roles_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.user_roles_id_seq', 4, true);


--
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 65, true);


--
-- Name: waiting_airlines_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.waiting_airlines_id_seq', 10, true);


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
-- Name: flight_history flight_history_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flight_history
    ADD CONSTRAINT flight_history_pkey PRIMARY KEY (id);


--
-- Name: flights flights_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.flights
    ADD CONSTRAINT flights_pk PRIMARY KEY (id);


--
-- Name: tickets_history tickets_history_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tickets_history
    ADD CONSTRAINT tickets_history_pkey PRIMARY KEY (id);


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
-- Name: waiting_airlines waiting_airlines_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.waiting_airlines
    ADD CONSTRAINT waiting_airlines_pk PRIMARY KEY (id);


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
-- Name: waiting_airlines_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX waiting_airlines_name_uindex ON public.airline_companies USING btree (name);


--
-- Name: waiting_airlines_user_id_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX waiting_airlines_user_id_uindex ON public.airline_companies USING btree (user_id);


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
-- Name: waiting_airlines waiting_airlines_users_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.waiting_airlines
    ADD CONSTRAINT waiting_airlines_users_id_fk FOREIGN KEY (user_id) REFERENCES public.users(id);


--
-- PostgreSQL database dump complete
--

