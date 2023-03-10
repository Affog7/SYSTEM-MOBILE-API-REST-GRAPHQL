[![Build Status](https://codefirst.iut.uca.fr/api/badges/augustin.affognon/APIWEB/status.svg)](https://codefirst.iut.uca.fr/augustin.affognon/APIWEB)  
[![Quality Gate Status](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=APIWEB&metric=alert_status&token=ec78ebab2c3249a471935edf1ebae23f27c864e2)](https://codefirst.iut.uca.fr/sonar/dashboard?id=APIWEB)
 
[![Bugs](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=APIWEB&metric=bugs&token=ec78ebab2c3249a471935edf1ebae23f27c864e2)](https://codefirst.iut.uca.fr/sonar/dashboard?id=APIWEB)
[![Code Smells](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=APIWEB&metric=code_smells&token=ec78ebab2c3249a471935edf1ebae23f27c864e2)](https://codefirst.iut.uca.fr/sonar/dashboard?id=APIWEB)
[![Coverage](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=APIWEB&metric=coverage&token=ec78ebab2c3249a471935edf1ebae23f27c864e2)](https://codefirst.iut.uca.fr/sonar/dashboard?id=APIWEB)  
[![Duplicated Lines (%)](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=APIWEB&metric=duplicated_lines_density&token=ec78ebab2c3249a471935edf1ebae23f27c864e2)](https://codefirst.iut.uca.fr/sonar/dashboard?id=APIWEB) 
[![Lines of Code](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=APIWEB&metric=ncloc&token=ec78ebab2c3249a471935edf1ebae23f27c864e2)](https://codefirst.iut.uca.fr/sonar/dashboard?id=APIWEB)
[![Maintainability Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=APIWEB&metric=sqale_rating&token=ec78ebab2c3249a471935edf1ebae23f27c864e2)](https://codefirst.iut.uca.fr/sonar/dashboard?id=APIWEB)
[![Reliability Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=APIWEB&metric=reliability_rating&token=ec78ebab2c3249a471935edf1ebae23f27c864e2)](https://codefirst.iut.uca.fr/sonar/dashboard?id=APIWEB)  
[![Security Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=APIWEB&metric=security_rating&token=ec78ebab2c3249a471935edf1ebae23f27c864e2)](https://codefirst.iut.uca.fr/sonar/dashboard?id=APIWEB)
[![Technical Debt](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=APIWEB&metric=sqale_index&token=ec78ebab2c3249a471935edf1ebae23f27c864e2)](https://codefirst.iut.uca.fr/sonar/dashboard?id=APIWEB)
[![Vulnerabilities](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=APIWEB&metric=vulnerabilities&token=ec78ebab2c3249a471935edf1ebae23f27c864e2)](https://codefirst.iut.uca.fr/sonar/dashboard?id=APIWEB)  

 
# APIWEB

Welcome on the APIWEB project!  

  

 
# ARCHITECTURE
<img src="Documentation/doc_images/systems.png" with=25%/>  
<div>
<img src="Documentation/doc_images/rest.png" with=25%/>  
<img src="Documentation/doc_images/graph.png" with=25%/>  

<div/>
# POURQUOI REST ET GRAPHQL?
** GRAPH QL

    GraphQL est un langage de requ??te pour les API qui permet aux clients de demander les donn??es qu'ils ont besoin et rien de plus. Il offre plusieurs avantages par rapport aux API REST traditionnelles, notamment :

    Interrogation de donn??es plus flexible : Avec GraphQL, les clients peuvent d??finir exactement les donn??es qu'ils souhaitent recevoir, sans avoir ?? acc??der ?? des informations suppl??mentaires.

    R??duction du nombre de requ??tes : En utilisant GraphQL, les clients peuvent effectuer une seule requ??te pour r??cup??rer toutes les donn??es n??cessaires, au lieu de faire plusieurs requ??tes ?? diff??rentes URL REST.

    Am??lioration de la performance : Les clients peuvent minimiser le nombre de requ??tes en demandant uniquement les donn??es dont ils ont besoin. Cela peut am??liorer les performances et la vitesse de l'application.

    Facilit?? d'??volution : Avec GraphQL, les clients peuvent demander des donn??es suppl??mentaires ou diff??rentes sans affecter les autres applications qui utilisent les m??mes API.

En utilisant GraphQL pour les produits et les stocks, vous pourriez faciliter la consommation de vos donn??es par les clients en leur donnant un contr??le plus granulaire sur les donn??es qu'ils souhaitent r??cup??rer. De plus, vous pourriez am??liorer les performances de l'application en r??duisant le nombre de requ??tes n??cessaires pour obtenir les donn??es, ce qui pourrait am??liorer l'exp??rience utilisateur.
** RESTFUL
ESTful API est un style d'architecture qui est souvent choisi pour les syst??mes de gestion de produits et de stocks en raison de plusieurs avantages:

    Simplicit??: RESTful est tr??s simple ?? comprendre et ?? mettre en ??uvre pour les d??veloppeurs. Les r??gles sont claires et les m??thodes HTTP standard telles que GET, POST, PUT et DELETE sont faciles ?? comprendre.

    Flexibilit??: RESTful permet aux d??veloppeurs de d??finir les ressources souhait??es pour leurs produits et stocks et de les requ??ter en cons??quence.

    Interop??rabilit??: RESTful est largement adopt?? et est donc tr??s compatible avec de nombreux syst??mes et technologies.

    Scalabilit??: RESTful est tr??s facile ?? ??chelle en fonction de la demande.

    Performance: Les performances RESTful sont souvent tr??s bonnes car elles reposent sur des protocoles standard tels que HTTP, ce qui facilite le traitement et la transmission des donn??es.

En r??sum??, RESTful est une option tr??s viable pour les syst??mes de gestion de produits et de stocks en raison de sa simplicit??, de sa flexibilit??, de son interop??rabilit??, de sa scalabilit?? et de ses performances.
**APIGATEWAY

Un "API Gateway" est un pattern d'architecture qui permet de centraliser la gestion des API d'une application. Il agit comme une passerelle entre les applications clientes et les services back-end, fournissant une interface unique pour les clients d'interagir avec les diff??rents services. Les avantages d'utiliser un API Gateway incluent :

    Abstraction des services back-end: Les services back-end peuvent ??tre modifi??s ou remplac??s sans affecter les applications clientes, car le gateway les abstrait.

    Authentification et autorisation: Le gateway peut ??tre configur?? pour g??rer l'authentification et l'autorisation des utilisateurs, ce qui peut faciliter la gestion de la s??curit??.

    Load balancing: Le gateway peut ??tre configur?? pour r??partir les requ??tes entre plusieurs instances d'un m??me service, ce qui peut am??liorer la disponibilit?? et les performances

# CONTROLEUR
## PRODUCTS
Ce code repr??sente un contr??leur de l'API Swagger pour une application de gestion de produits. Il comporte les m??thodes courantes pour g??rer les produits, telles que la r??cup??ration de tous les produits (GetAll), la r??cup??ration d'un produit par identifiant (GetById), la cr??ation d'un nouveau produit (Create), la mise ?? jour d'un produit existant (Update) et la suppression d'un produit (Delete).

La m??thode GetAll prend en entr??e les param??tres facultatifs page et taille, qui permettent de paginer les r??sultats. Elle utilise le service de produit pour r??cup??rer la liste compl??te de produits et renvoie ensuite une r??ponse OK avec les donn??es de la page demand??e.

La m??thode GetById r??cup??re un produit en fonction de son identifiant et renvoie une r??ponse OK si le produit existe, ou une r??ponse NotFound si le produit n'a pas ??t?? trouv??.

La m??thode Create utilise l'objet ProductDTO en entr??e pour cr??er un nouveau produit et renvoie une r??ponse CreatedAtAction avec les informations sur le nouveau produit.

La m??thode Update prend en entr??e l'identifiant du produit ?? mettre ?? jour ainsi que les nouvelles informations sur le produit. Si le produit n'existe pas, elle renvoie une r??ponse NotFound, sinon elle utilise le service de produit pour effectuer la mise ?? jour et renvoie une r??ponse NoContent.

Enfin, la m??thode Delete prend en entr??e l'identifiant du produit ?? supprimer. Si le produit n'existe pas, elle renvoie une r??ponse NotFound, sinon elle utilise le service de produit pour effectuer la suppression et renvoie une r??ponse NoContent.


## STOCKS
    La m??thode Index avec l'attribut [HttpGet] renvoie tous les stocks en utilisant le service _stockService avec la m??thode GetAll(). Le r??sultat est retourn?? en utilisant la m??thode Ok(stock).

    La m??thode GetById avec l'attribut [HttpGet("{id}")] renvoie un stock sp??cifique en utilisant l'ID en tant que param??tre. Si le stock n'est pas trouv??, la m??thode NotFound() est renvoy??e. Sinon, le r??sultat est retourn?? en utilisant la m??thode Ok(stock).

    La m??thode Create avec l'attribut [HttpPost] permet de cr??er un nouveau stock en utilisant les donn??es du corps de la requ??te envoy??e sous forme de StockDTO. La m??thode CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock) est utilis??e pour renvoyer un code de statut 201 (Cr????) avec les informations sur le nouveau stock.

    La m??thode Update avec l'attribut [HttpPut("{id}")] permet de mettre ?? jour un stock existant en utilisant les donn??es du corps de la requ??te envoy??e sous forme de StockDTO et l'ID du stock ?? mettre ?? jour en tant que param??tre. Si le stock n'est pas trouv??, la m??thode NotFound() est renvoy??e. Sinon, la m??thode NoContent() est renvoy??e pour indiquer que la mise ?? jour s'est correctement d??roul??e.

    La m??thode Delete avec l'attribut [HttpDelete("{id}")] permet de supprimer un stock existant en utilisant l'ID du stock ?? supprimer en tant que param??tre. Si le stock n'est pas trouv??, la m??thode NotFound() est renvoy??e. Sinon, la m??thode NoContent() est renvoy??e pour indiquer que la suppression s'est correctement d??roul??e.
