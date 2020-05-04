# PosTerminalApi_project
A demo project using Net Core Web Api to implement a solution for the following problem in C#.

Consider a grocery market where items have prices per unit but also volume prices. For example,
Apples may be $1.25 each, or 3 for $3.
Implement an Web API solution for a point-of-sale scanning system that accepts an arbitrary ordering of
products, similar to what would happen at an actual checkout line, then returns the correct total
price for an entire shopping cart based on per-unit or volume prices as applicable.
Here are the products listed by code and the prices to use. There is no sales tax.

Product Code Price

A $1.25 each, or 3 for $3.00

B $4.25

C $1.00 or $5 for a six-pack

D $0.75

For example,

var terminal = new PointOfSaleTerminal()

terminal.SetPricing(...);

terminal.ScanProduct("A");

terminal.ScanProduct("C");
// etc

decimal result = terminal.CalculateTotal();

Unit tests demo:
1. Scan these items in this order: ABCDABA

Verify that the total price is $13.25
2. Scan these items in this order: CCCCCCC

Verify that the total price is $6.00
3. Scan these items in this order: ABCD

Verify that the total price is $7.25
