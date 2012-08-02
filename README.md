During this meeting, we discussed:
- TDD is an engineering/development practice.
- BDD is a whole team activity.
- NUnit is a great TDD tool.
- MSpec is a great TDD tool.
- MSpec != BDD.
 -BDD is not about developer tests, but rather about the whole team (including business users) thinking about how to know when a feature is complete and the developers should stop writing new code.

We discussed how FitNesse is a true BDD tool because it separates the business concepts from the programming concepts.
2 major advantages to FitNesse for a team of all developers include:
- It forces you as a developer to think about the data, not the code while defining accepance specs for a feature
- Writing fixtures will help you define your API and help you find the rough spots in the API

To run FitNesse:
- cd into the packages/FitNesse directory
- java -jar fitnesse.jar -p 8000
- browse to localhost:8000
