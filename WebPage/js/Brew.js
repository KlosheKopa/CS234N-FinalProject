//couldn't get my add batches to work. More detailed comment by that method. 
class BrewPage{

    constructor(){
        this.state = {
            brewId: "",
            recipes: [],
            batches: [],
            recipeName: "",
            recipeVersion: null
        };

        this.server = "https://localhost:5001/api"
        this.url = this.server + "/batch";

        this.$form = document.querySelector('#batchForm');
        this.$batchRows = document.querySelector('#batchRows');
        this.$recipeName = document.querySelector('#recipeName');
        this.$batchSize = document.querySelector('#batchSize');
        this.$startDate = document.querySelector('#sDate');
        this.$endDate = document.querySelector('#eDate');
        this.$checkBtn = document.querySelector('#checkBtn');
        this.$addBtn = document.querySelector('#addBtn');
        this.$ingredientCheck = document.querySelector('#checkIngredient');
        this.$containerCheck = document.querySelector('#containerCheck');
        this.$inventory = document.querySelector('#inventory');

        document.getElementById("addBtn").onclick = this.onAddBatch.bind(this);


        this.bindAllMethods();
        this.fetchRecipes();
        this.fetchBatches();
    }

    bindAllMethods(){
        this.fetchRecipes = this.fetchRecipes.bind(this);
        this.loadRecipes = this.loadRecipes.bind(this);
        this.fetchBatches = this.fetchBatches.bind(this);
        this.loadRecipe = this.loadRecipe.bind(this);
        this.setUpRows = this.setUpRows.bind(this);
        this.fetchBatch = this.fetchBatch.bind(this);
    }

    fetchRecipes() {
        fetch(`${this.server}/recipe`)
        .then(response => response.json())
        .then(data => {
            if (data.length == 0) {
                alert("Can't load recipes. Can't schedule a brew without recipes.");
            }
            else{
                this.state.recipes = data;
                this.loadRecipes();
            }
        })
        .catch(error => {
            alert('There was a problem getting info!');
        })
    }

    loadRecipes(){
        let defaultOption = `<option value="" ${(!this.state.customer)?"selected":""}></option>`;
        let recipeHtml = this.state.recipes.reduce(
        (html, state, index) => html += this.loadRecipe(state, index), defaultOption
        );
        this.$recipeName.innerHTML = recipeHtml;
    }

    loadRecipe(state, index){
        return `<option value=${state.recipeId} ${(this.state.brew && this.state.recipes.recipeId == state.recipeId)?"selected":""}>${state.name}</option>`
    }

    fetchBatches(){
        fetch(`${this.url}`)
        .then(response => response.json())
        .then(data => {
            if (data.length == 0){
                alert('There are no scheduled batchs.')
            }
            else
            {
                this.state.batches = data;
                this.setUpRows();
            }
        })
        .catch(error => {
            alert('There was a problem getting batches info!'); 
          });
    }

    fetchBatch(id){
        fetch(`${this.url}/${id + 1}`)
        .then(response => response.json())
        .then(data => {
            if (data.length == 0){
                alert('Scheduled batch does not exist.')
            }
            else
            {
                this.state.brew = data;
            }
        })
        .catch(error => {
            alert('There was a problem getting batch info!'); 
          });
    }

    setUpRows(){
        let defaultBatch = '<tr><th>Name</th><th>Version</th><th>Ingredients</th><th>Batch Size</th><th>Start Date</th><th>End Date</th></tr>';//Not using the ingredients column. My idea was for it to be a link to the exact amount of ingredients needed for the batch
        let rId;
        let rName;
        let rVersion;
        let bVolume;
        let bStartdate;
        let bEnddate;
        let batchHtml = defaultBatch;

        for (let i = 0; i < this.state.batches.length; i++)
        {
            rId = this.state.batches[i].recipeId;
            this.getRecipeName(rId);
            rName = this.state.recipeName;
            bVolume = this.state.batches[i].volume;
            bStartdate = this.state.batches[i].scheduledStartDate;
            bEnddate = this.state.batches[i].estimatedFinishDate;
            
            this.getRecipeVersion(rId);
            rVersion = this.state.recipeVersion;

            batchHtml += `<tr><td>${rName}</td><td>${rVersion}</td><td></td><td>${bVolume}</td><td>${bStartdate}</td><td>${bEnddate}</td></tr>`;
            
        }
        this.$batchRows.innerHTML = batchHtml;
    }

    getRecipeName(id){
        for (let i = 0; i < this.state.recipes.length; i++)
        {
            if (id == this.state.recipes[i].recipeId)
            {
                this.state.recipeName = this.state.recipes[i].name;
                return
            }
        }
    }

    getRecipeVersion(id){
        for (let i = 0; i < this.state.recipes.length; i++)
        {
            if (id == this.state.recipes[i].recipeId)
            {
                this.state.recipeVersion = this.state.recipes[i].version;
                return
            }
        }
    }

    //keep getting some other sort of CORS error which wouldn't be solved from the extensions in the browser
    //Access to fetch at 'https://localhost:5001/api/batch' from origin 'http://localhost:8080' has been blocked by CORS policy: Response to preflight request doesn't pass access control check: It does not have HTTP ok status.
    onAddBatch(){
        fetch(`${this.url}`,{
            method: 'POST',
            headers:{
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                recipeId: this.$recipeName.value,
                equipmentId: 1,
                volume: this.$batchSize,
                scheduledStartDate: this.$endDate.value,
                startDate: null,
                estimatedFinishDate: this.$startDate.value,
                finishDate: null,
                unitCost: null,
                notes: null,
                tasteNotes: null,
                tasteRating: null,
                og: null,
                fg: null,
                carbonation: null,
                fermentationStages: null,
                primaryAge: null,
                primaryTemp: null,
                secondaryAge: null,
                secondaryTemp: null,
                tertiaryAge: null,
                age: null,
                temp: null,
                ibu: null,
                ibuMethod: null,
                abv: null,
                actualEfficiency: null,
                calories: null,
                carbonationUsed: null,
                forcedCarbonation: null,
                kegPrimingFactor: null,
                carbonationTemp: null,
                equipment: null,
                recipe: null,
                batchContainer: [],
                ingredientInventorySubtraction: [],
                inventoryTransaction: [],
                product: []
            })
        })
        .then(response => response.json())
        .then(data => {
            this.batches.push(data);
        })
        .catch(error => {
            alert('There was an error adding the batch.');
        })
    }

}

window.addEventListener("load", () => new BrewPage());