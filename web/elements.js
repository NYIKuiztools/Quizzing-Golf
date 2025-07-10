document.addEventListener('DOMContentLoaded', function () {
	window.manager.elements = {

		buttons: {
			start: document.getElementById('start'),
			begin: document.getElementById("begin"),
			next: document.getElementById('next'),
			showAnswers: document.getElementById('submit'),
		},

		settings: document.getElementById('settingsPage'),

		word: document.getElementById('word'),
		answers: {
			book1: document.getElementById('Book1'),
			chapter1: document.getElementById('Chapter1'),
			verse1: document.getElementById('Verse1'),
		},
		answersPage: document.getElementById("answers"),

		resultPage: document.getElementById('resultPage'),
		result: document.getElementById('result'),


	}
})