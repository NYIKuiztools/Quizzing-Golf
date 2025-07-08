window.manager = {
	buttons: {
		start: function () {
			manager.elements.buttons.start.classList.add('hidden');
			manager.elements.settings.classList.remove('hidden');
		},
		begin: function () {
			manager.elements.answersPage.classList.remove('hidden');
			manager.elements.settings.classList.add('hidden');
			nextWord();
		}
	}
}

		//#! Game
const elements = manager.elements;
function nextWord() {

}
function getWords() {
	
}