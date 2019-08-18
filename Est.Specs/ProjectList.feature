Feature: Project list

View a list of projects containing estimations.

Scenario: View an empty list
	Given I am a new user
	When I view the project list
	Then the page contains 0 projects
