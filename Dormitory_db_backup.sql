--
-- PostgreSQL database dump
--

\restrict UjdJ4nBYU7cvGEwuZZTq4U9lltV5sfMeUVjKJgpvy5DF4kJLd1yyJsRsZzshMVh

-- Dumped from database version 18.2
-- Dumped by pg_dump version 18.1

-- Started on 2026-02-19 14:01:22

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 5066 (class 0 OID 16517)
-- Dependencies: 225
-- Data for Name: Invoices; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Invoices" ("Id", "RoomId", "TotalElectricity", "TotalWater", "GrandTotal", "Status", "BillingMonth", "CurrentElectricityMeter", "CurrentWaterMeter", "PreviousElectricityMeter", "PreviousWaterMeter", "CreatedAt") FROM stdin;
2	1	500	100	4100	Pending	2026-02-16 21:04:46.695652+07	0	0	0	0	-infinity
3	51	500	50	5050	Pending	2026-02-16 21:43:06.802039+07	0	0	0	0	-infinity
5	1	500	100	4100.00	Pending	2026-02-16 16:12:25.176761+07	100	10	0	0	2026-02-16 16:12:25.176251+07
6	1	250	50	3800.00	Pending	2026-02-16 16:26:05.509638+07	150	15	100	10	2026-02-16 16:26:05.509391+07
4	1	500	100	4100	Paid	2026-02-16 22:40:08.90223+07	100	10	0	0	-infinity
7	1	505	100	4105.00	Paid	2026-02-16 16:39:44.717833+07	251	25	150	15	2026-02-16 16:39:44.717576+07
8	91	500	100	5100.00	Paid	2026-02-17 13:06:56.411978+07	100	10	0	0	2026-02-17 13:06:56.411721+07
9	1	5	10	3515.00	Pending	2026-02-17 13:58:22.031623+07	252	26	251	25	2026-02-17 13:58:22.031144+07
10	4	500	100	4100.00	Paid	2026-02-18 07:52:27.263162+07	100	10	0	0	2026-02-18 07:52:27.262421+07
11	4	5	10	3515.00	Pending	2026-02-18 07:53:42.772044+07	101	11	100	10	2026-02-18 07:53:42.772043+07
12	4	250	50	3800.00	WaitingApproval	2026-02-19 06:37:10.542988+07	151	16	101	11	2026-02-19 06:37:10.542746+07
\.


--
-- TOC entry 5072 (class 0 OID 16579)
-- Dependencies: 231
-- Data for Name: Payments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Payments" ("Id", "InvoiceId", "SlipUrl", "PaymentDate", "Status", "CreatedAt") FROM stdin;
1	2	/uploads/slips/256526e7-4053-4b12-b2cf-b6f90b441ad5.jpg	2026-02-16 21:47:56.584284+07	Approved	-infinity
3	2	/uploads/slips/2ecedf3f-39b6-4ca9-99d8-b7ae1a17ad12.jpg	2026-02-16 22:00:21.879368+07	Approved	-infinity
2	2	/uploads/slips/bdc2c238-4b1e-458b-a87e-8c3b856272dd.jpg	2026-02-16 21:59:44.871768+07	Rejected	-infinity
4	4	/uploads/slips/21650023-9890-4152-9c77-4fc3a4497b78.jpg	2026-02-16 22:40:23.112484+07	Approved	-infinity
5	4	/uploads/slips/d1bb01e7-1bea-45d5-83a4-7523ef5b8bf3.jpg	2026-02-16 22:40:57.194005+07	Approved	-infinity
10	8	/uploads/slips/57046b85-695b-4ba9-b3f8-f535c10fc5b1_ec82ca37-3f5a-46ae-aba3-0645653da983.jpg	-infinity	Approved	2026-02-17 13:20:29.061678+07
11	10	/uploads/slips/e49d1901-e35f-4328-99a9-022da81883a1_Screenshot 2026-02-17 213059.png	-infinity	Approved	2026-02-18 07:52:47.497495+07
12	12	/uploads/slips/955c189e-067f-4048-a6a5-95b2969be252_ec82ca37-3f5a-46ae-aba3-0645653da983.jpg	-infinity	Rejected	2026-02-19 06:37:47.008394+07
13	12	/uploads/slips/850f9eb9-b3d4-4667-a15c-634effc5b4d6_ec82ca37-3f5a-46ae-aba3-0645653da983.jpg	2026-02-19 13:49:36.718538+07	Pending	2026-02-19 06:49:36.71837+07
\.


--
-- TOC entry 5062 (class 0 OID 16478)
-- Dependencies: 221
-- Data for Name: Rooms; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Rooms" ("Id", "RoomNumber", "Type", "MonthlyRent", "Status") FROM stdin;
2	102	Fan	3500.00	Available
3	103	Fan	3500.00	Available
5	105	Fan	3500.00	Available
6	106	Fan	3500.00	Available
7	107	Fan	3500.00	Available
8	108	Fan	3500.00	Available
9	109	Fan	3500.00	Available
10	110	Fan	3500.00	Available
11	111	Fan	3500.00	Available
12	112	Fan	3500.00	Available
13	113	Fan	3500.00	Available
14	114	Fan	3500.00	Available
15	115	Fan	3500.00	Available
16	116	Fan	3500.00	Available
17	117	Fan	3500.00	Available
18	118	Fan	3500.00	Available
19	119	Fan	3500.00	Available
20	120	Fan	3500.00	Available
21	121	Fan	3500.00	Available
22	122	Fan	3500.00	Available
23	123	Fan	3500.00	Available
24	124	Fan	3500.00	Available
25	125	Fan	3500.00	Available
26	126	Fan	3500.00	Available
27	127	Fan	3500.00	Available
28	128	Fan	3500.00	Available
29	129	Fan	3500.00	Available
30	130	Fan	3500.00	Available
31	131	Fan	3500.00	Available
32	132	Fan	3500.00	Available
33	133	Fan	3500.00	Available
34	134	Fan	3500.00	Available
35	135	Fan	3500.00	Available
36	136	Fan	3500.00	Available
37	137	Fan	3500.00	Available
38	138	Fan	3500.00	Available
39	139	Fan	3500.00	Available
40	140	Fan	3500.00	Available
42	142	Fan	3500.00	Available
43	143	Fan	3500.00	Available
44	144	Fan	3500.00	Available
45	145	Fan	3500.00	Available
46	146	Fan	3500.00	Available
47	147	Fan	3500.00	Available
48	148	Fan	3500.00	Available
49	149	Fan	3500.00	Available
50	150	Fan	3500.00	Available
52	202	Air	4500.00	Available
53	203	Air	4500.00	Available
54	204	Air	4500.00	Available
55	205	Air	4500.00	Available
56	206	Air	4500.00	Available
57	207	Air	4500.00	Available
58	208	Air	4500.00	Available
59	209	Air	4500.00	Available
60	210	Air	4500.00	Available
61	211	Air	4500.00	Available
62	212	Air	4500.00	Available
63	213	Air	4500.00	Available
64	214	Air	4500.00	Available
65	215	Air	4500.00	Available
66	216	Air	4500.00	Available
67	217	Air	4500.00	Available
68	218	Air	4500.00	Available
69	219	Air	4500.00	Available
70	220	Air	4500.00	Available
71	221	Air	4500.00	Available
72	222	Air	4500.00	Available
73	223	Air	4500.00	Available
74	224	Air	4500.00	Available
75	225	Air	4500.00	Available
76	226	Air	4500.00	Available
77	227	Air	4500.00	Available
79	229	Air	4500.00	Available
80	230	Air	4500.00	Available
81	231	Air	4500.00	Available
82	232	Air	4500.00	Available
83	233	Air	4500.00	Available
84	234	Air	4500.00	Available
85	235	Air	4500.00	Available
86	236	Air	4500.00	Available
87	237	Air	4500.00	Available
88	238	Air	4500.00	Available
89	239	Air	4500.00	Available
90	240	Air	4500.00	Available
92	242	Air	4500.00	Available
93	243	Air	4500.00	Available
94	244	Air	4500.00	Available
95	245	Air	4500.00	Available
96	246	Air	4500.00	Available
97	247	Air	4500.00	Available
98	248	Air	4500.00	Available
99	249	Air	4500.00	Available
100	250	Air	4500.00	Available
78	228	Air	4500.00	Available
41	141	Fan	3500.00	Available
51	201	Air	4500.00	Available
91	241	Air	4500.00	Occupied
1	101	Fan	3500.00	Occupied
4	104	Fan	3500.00	Occupied
\.


--
-- TOC entry 5064 (class 0 OID 16491)
-- Dependencies: 223
-- Data for Name: Tenants; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Tenants" ("Id", "Name", "PhoneNumber", "CheckInDate", "RoomId") FROM stdin;
9	Max verstrappen	012 345 6789	2026-02-17 13:06:13.49951+07	91
10	Pu	1231231231	2026-02-17 13:38:30.466504+07	1
11	Mark	1231231231	2026-02-18 07:51:53.535032+07	4
\.


--
-- TOC entry 5070 (class 0 OID 16552)
-- Dependencies: 229
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Users" ("Id", "Username", "PasswordHash", "Role", "RoomId") FROM stdin;
1	admin	1234	Admin	\N
12	user241	241	User	91
13	user101	101	User	1
14	user104	104	User	4
\.


--
-- TOC entry 5068 (class 0 OID 16535)
-- Dependencies: 227
-- Data for Name: UtilityUsages; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."UtilityUsages" ("Id", "RoomId", "PreviousElectricityMeter", "PreviousWaterMeter", "ReadingDate", "CurrentElectricityMeter", "CurrentWaterMeter") FROM stdin;
1	1	0	0	2026-02-16 14:04:46.627+07	100	10
2	51	0	0	2026-02-16 14:43:06.777+07	100	5
3	1	0	0	2026-02-16 15:40:08.868+07	100	10
4	1	0	0	2026-02-16 16:12:25.039+07	100	10
5	1	100	10	2026-02-16 16:26:05.479+07	150	15
6	1	150	15	2026-02-16 16:39:44.689+07	251	25
7	91	0	0	2026-02-17 13:06:56.375+07	100	10
8	1	251	25	2026-02-17 13:58:22.008+07	252	26
9	4	0	0	2026-02-18 07:52:27.242+07	100	10
10	4	100	10	2026-02-18 07:53:42.764+07	101	11
11	4	101	11	2026-02-19 06:37:10.511+07	151	16
\.


--
-- TOC entry 5060 (class 0 OID 16470)
-- Dependencies: 219
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20260215080835_InitialCreate	10.0.3
20260215090940_AddTenantTable	10.0.3
20260215094718_AddTenantsTable	10.0.3
20260215100059_AddUtilityAndInvoiceTables	10.0.3
20260215100417_AddUserTable	10.0.3
20260216114106_AddUtilityUsageFields	10.0.3
20260216140209_AddCreatedAtToInvoices	10.0.3
20260216140826_AddPaymentTable	10.0.3
20260216151641_AddInvoiceRoomRelation	10.0.3
20260216153933_AddMeterFieldsToInvoice	10.0.3
20260216160630_FixInvoiceController	10.0.3
20260216161126_UpdateInvoiceLogic	10.0.3
20260216161921_AddCreatedAtToPayment	10.0.3
\.


--
-- TOC entry 5078 (class 0 OID 0)
-- Dependencies: 224
-- Name: Invoices_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Invoices_Id_seq"', 12, true);


--
-- TOC entry 5079 (class 0 OID 0)
-- Dependencies: 230
-- Name: Payments_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Payments_Id_seq"', 13, true);


--
-- TOC entry 5080 (class 0 OID 0)
-- Dependencies: 220
-- Name: Rooms_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Rooms_Id_seq"', 100, true);


--
-- TOC entry 5081 (class 0 OID 0)
-- Dependencies: 222
-- Name: Tenant_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Tenant_Id_seq"', 11, true);


--
-- TOC entry 5082 (class 0 OID 0)
-- Dependencies: 228
-- Name: Users_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Users_Id_seq"', 14, true);


--
-- TOC entry 5083 (class 0 OID 0)
-- Dependencies: 226
-- Name: UtilityUsages_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."UtilityUsages_Id_seq"', 11, true);


-- Completed on 2026-02-19 14:01:22

--
-- PostgreSQL database dump complete
--

\unrestrict UjdJ4nBYU7cvGEwuZZTq4U9lltV5sfMeUVjKJgpvy5DF4kJLd1yyJsRsZzshMVh

