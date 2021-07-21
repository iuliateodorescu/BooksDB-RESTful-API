using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAPI.Repository.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    EditionYear = table.Column<int>(nullable: false),
                    Publisher = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "LibraryItems",
                columns: table => new
                {
                    LibraryItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryItems", x => x.LibraryItemId);
                    table.ForeignKey(
                        name: "FK_LibraryItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Description", "EditionYear", "ImageUrl", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "Arthur Golden", "In this literary tour de force, novelist Arthur Golden enters a remote and shimmeringly exotic world. For the protagonist of this peerlessly observant first novel is Sayuri, one of Japan's most celebrated geisha, a woman who is both performer and courtesan, slave and goddess. We follow Sayuri from her childhood in an impoverished fishing village, where in 1929, she is sold to a representative of a geisha house, who is drawn by the child's unusual blue-grey eyes. From there she is taken to Gion, the pleasure district of Kyoto. She is nine years old. In the years that follow, as she works to pay back the price of her purchase, Sayuri will be schooled in music and dance, learn to apply the geisha's elaborate makeup, wear elaborate kimono, and care for a coiffure so fragile that it requires a special pillow.She will also acquire a magnanimous tutor and a venomous rival.Surviving the intrigues of her trade and the upheavals of war, the resourceful Sayuri is a romantic heroine on the order of Jane Eyre and Scarlett O'Hara. And \"Memoirs of a Geisha\" is a triumphant work - suspenseful, and utterly persuasive.", 2005, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9781/4000/9781400096893.jpg", "Random House", "Memoirs of a Geisha" },
                    { 2, "J.D.Salinger", "The Catcher in Rye is the ultimate novel for disaffected youth, but it's relevant to all ages. The story is told by Holden Caulfield, a seventeen- year-old dropout who has just been kicked out of his fourth school. Throughout, Holden dissects the 'phony' aspects of society, and the 'phonies' themselves: the headmaster whose affability depends on the wealth of the parents, his roommate who scores with girls using sickly-sweet affection.Lazy in style, full of slang and swear words, it's a novel whose interest and appeal comes from its observations rather than its plot intrigues (in conventional terms, there is hardly any plot at all). Salinger's style creates an effect of conversation, it is as though Holden is speaking to you personally, as though you too have seen through the pretences of the American Dream and are growing up unable to see the point of living in, or contributing to, the society around you.Written with the clarity of a boy leaving childhood, it deals with society, love, loss, and expectations without ever falling into the clutch of a cliche.", 2010, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/2419/9780241950425.jpg", "Penguin Books", "The Catcher in the Rye" },
                    { 3, "Charles Dickens", "'A parish child - the orphan of a workhouse - the humble, half-starved drudge - to be cuffed and buffeted through the world, despised by all, and pitied by none'Dark, mysterious and mordantly funny, Oliver Twist features some of the most memorably drawn villains in all of fiction - the treacherous gangmaster Fagin, the menacing thug Bill Sikes, the Artful Dodger and their den of thieves in the grimy London backstreets. Dicken's novel is both an angry indictment of poverty, and an adventure filled with an air of threat and pervasive evil.", 2012, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1411/9780141198880.jpg", "Penguin Books", "Oliver Twist" },
                    { 4, "Oscar Wilde", "'I am jealous of everything whose beauty does not die. I am jealous of the portrait you have painted of me ... Why did you paint it? It will mock me some day - mock me horribly!'A story of evil, debauchery and scandal, Oscar Wilde's only novel tells of Dorian Gray, a beautiful yet corrupt man. When he wishes that a perfect portrait of himself would bear the signs of ageing in his place, the picture becomes his hideous secret, as it follows Dorian's own downward spiral into cruelty and depravity. The Picture of Dorian Gray is a masterpiece of the evil in men's hearts, and is as controversial and alluring as Wilde himself.", 2012, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1411/9780141199498.jpg", "Penguin Books", "The Picture of Dorian Gray" },
                    { 5, "Daniel Keyes", "Winner of both the Hugo and Nebula Awards, the powerful, classic story about a man who receives an operation that turns him into a genius...and introduces him to heartache. Charlie Gordon is about to embark upon an unprecedented journey. Born with an unusually low IQ, he has been chosen as the perfect subject for an experimental surgery that researchers hope will increase his intelligence-a procedure that has already been highly successful when tested on a lab mouse named Algernon. As the treatment takes effect, Charlie's intelligence expands until it surpasses that of the doctors who engineered his metamorphosis. The experiment appears to be a scientific breakthrough of paramount importance, until Algernon suddenly deteriorates. Will the same happen to Charlie?", 2005, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1560/9780156030304.jpg", "Mariner Books", "Flowers for Algernon" },
                    { 6, "E.Scott Fitzgerald", "'It was one of those rare smiles with a quality of eternal reassurance in it, that you may come across four or five times in life'Jay Gatsby is the man who has everything. But one thing will always be out of his reach ... Everybody who is anybody is seen at his glittering parties. Day and night his Long Island mansion buzzes with bright young things drinking, dancing and debating his mysterious character. For Gatsby - young, handsome, fabulously rich - always seems alone in the crowd, watching and waiting, though no one knows what for. Beneath the shimmering surface of his life he is hiding a secret: a silent longing that can never be fulfilled.And soon this destructive obsession will force his world to unravel.", 2018, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/2413/9780241341469.jpg", "Penguin Books", "The Great Gatsby" },
                    { 7, "Charles Dickens", "Great Expectations, Dickens's funny, frightening and tender portrayal of the orphan Pip's journey of self-discovery, is one of his best-loved works. Showing how a young man's life is transformed by a mysterious series of events - an encounter with an escaped prisoner; a visit to a black-hearted old woman and a beautiful girl; a fortune from a secret donor - Dickens's late novel is a masterpiece of psychological and moral truth, and Pip among his greatest creations.", 2012, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1411/9780141198897.jpg", "Penguin Books", "Great Expectations" },
                    { 8, "John Steinbek", "California's fertile Salinas Valley is home to two families whose destinies are fruitfully, and fatally, intertwined. Over the generations, between the beginning of the twentieth century and the end of the First World War, the Trasks and the Hamiltons will helplessly replay the fall of Adam and Eve and the murderous rivalry of Cain and Abel.East of Eden was considered by Steinbeck to be his magnum opus, and its epic scope and memorable characters, exploring universal themes of love and identity, ensure it remains one of America's most enduring novels.", 2017, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/2419/9780241980354.jpg", "Penguin Books", "East of Eden" },
                    { 9, "Thomas Hardy", "When Tess Durbeyfield is driven by family poverty to claim kinship with the wealthy D'Urbervilles and seek a portion of their family fortune, meeting her 'cousin' Alec proves to be her downfall. A very different man, Angel Clare, seems to offer her love and salvation, but Tess must choose whether to reveal her past or remain silent in the hope of a peaceful future. With its sensitive depiction of the wronged Tess and powerful criticism of social convention, Tess of the D'Urbervilles is one of the most moving and poetic of Hardy's novels.", 2012, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1411/9780141199948.jpg", "Penguin Books", "Tess of the D'Urbervilles" },
                    { 10, "Arthur Conan Doyle", "When Dr John Watson takes rooms in Baker Street with amateur detective Sherlock Holmes, he has no idea that he is about to enter a shadowy world of criminality and violence. Accompanying Holmes to an ill-omened house in south London, Watson is startled to find a dead man whose face is contorted in a rictus of horror. There is no mark of violence on the body yet a single word is written on the wall in blood. Dr Watson is as baffled as the police, but Holmes's brilliant analytical skills soon uncover a trail of murder, revenge and lost love .", 2014, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1413/9780141395524.jpg", "Penguin Books", "A Study in Scarlet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibraryItems_BookId",
                table: "LibraryItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryItems_UserId",
                table: "LibraryItems",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryItems");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
