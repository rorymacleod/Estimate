Feature: Estimation

Feature description

Scenario: Empty estimation
	Given a new estimation
	Then the estimatation contains 0 lines
  And the expected duration is 0
  And the actual duration is 0
  And the remaining duration is 0
  
Scenario: Add a new estimation line
  Given a new estimation
  When I add a new estimation line
  Then the estimation contains 1 lines
  And the expected duration is 0
  
Scenario: Add values to estimation line
  Given an estimation with a single empty line
  When I add a best value of <best>
  And I add a likely value of <likely>
  And I add a worst value of <worst>
  Then the expected duration is <expected>
  And the actual duration is 0
  And the remaining duration is <expected>
