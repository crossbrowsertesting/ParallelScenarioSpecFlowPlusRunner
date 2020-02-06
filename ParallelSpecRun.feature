Feature: feature
Test parallel 

@mytag
Scenario: Search for SpecFlow on Google using Google Chrome
Given I navigate to the page "https://www.google.com" 
And I see the page is loaded
When I enter Search Keyword in the Search Text box
And I click on Search Button
Then Search items shows the items related to SpecFlow



Scenario: Search for SpecFlow on Google using Microsoft Firefox
Given I navigate to the page "https://www.google.com" with Firefox
And I see the page is loaded with Firefox
When I enter Search Keyword in the Search Text box with Firefox
And I click on Search Button with Firefox
Then Search items shows the items related to SpecFlow with Firefox