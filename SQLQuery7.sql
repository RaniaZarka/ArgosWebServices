CREATE TABLE [dbo].[customer] (
    [customer_id] INT          NOT NULL,
    [cust_name]   VARCHAR (50) NOT NULL,
    [city]        VARCHAR (50) NOT NULL,
    [grade]       INT          NOT NULL,
    [salesman_id] INT          NULL,
    PRIMARY KEY CLUSTERED ([customer_id] ASC),
    CONSTRAINT [FK_customer_Salesman] FOREIGN KEY ([salesman_id]) REFERENCES [dbo].[salesman] ([salesman_id])
);
go

CREATE TABLE [dbo].[orders] (
    [ord_no]      INT        NOT NULL,
    [purch_amt]   FLOAT (53) NOT NULL,
    [ord_date]    DATE       NOT NULL,
    [customer_id] INT        NOT NULL,
    [salesman_id] INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([ord_no] ASC),
    CONSTRAINT [FK_orders_customer] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[customer] ([customer_id]),
    CONSTRAINT [FK_orders_salesman] FOREIGN KEY ([salesman_id]) REFERENCES [dbo].[salesman] ([salesman_id])
);
go

CREATE TABLE [dbo].[salesman] (
    [salesman_id] INT          NOT NULL,
    [name]        VARCHAR (50) NOT NULL,
    [city]        VARCHAR (50) NOT NULL,
    [commission]  FLOAT (53)   NOT NULL,
    PRIMARY KEY CLUSTERED ([salesman_id] ASC)
);
