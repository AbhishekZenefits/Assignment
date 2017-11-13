
    var chart_config = {
        chart: {
            container: "#collapsable-example",

            animateOnInit: true,
            
            node: {
                collapsable: true
            },
            animation: {
                nodeAnimation: "easeOutBounce",
                nodeSpeed: 700,
                connectorsAnimation: "bounce",
                connectorsSpeed: 700
            }
        },
        nodeStructure: {
            image: "images/malory.png",
            children: [
                {
                    image: "images/lana.png",
                    collapsed: true,
                    children: [
                        {
                            image: "images/figgs.png"
                        }
                    ]
                },
                {
                    image: "images/sterling.png",
                    childrenDropLevel: 1,
                    children: [
                        {
                            image: "images/woodhouse.png"
                        }
                    ]
                },
                {
                    pseudo: true,
                    children: [
                        {
                            image: "images/cheryl.png"
                        },
                        {
                            image: "images/pam.png"
                        }
                    ]
                }
            ]
        }
    };

/* Array approach
    var config = {
        container: "#collapsable-example",

        animateOnInit: true,
        
        node: {
            collapsable: true
        },
        animation: {
            nodeAnimation: "easeOutBounce",
            nodeSpeed: 700,
            connectorsAnimation: "bounce",
            connectorsSpeed: 700
        }
    },
    malory = {
        image: "images/malory.png"
    },

    lana = {
        parent: malory,
        image: "images/lana.png"
    }

    figgs = {
        parent: lana,
        image: "images/figgs.png"
    }

    sterling = {
        parent: malory,
        childrenDropLevel: 1,
        image: "images/sterling.png"
    },

    woodhouse = {
        parent: sterling,
        image: "images/woodhouse.png"
    },

    pseudo = {
        parent: malory,
        pseudo: true
    },

    cheryl = {
        parent: pseudo,
        image: "images/cheryl.png"
    },

    pam = {
        parent: pseudo,
        image: "images/pam.png"
    },

    chart_config = [config, malory, lana, figgs, sterling, woodhouse, pseudo, pam, cheryl];

*/