﻿// <auto-generated />
using BooksAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BooksAPI.Repository.Migrations
{
    [DbContext(typeof(BooksDbContext))]
    [Migration("20210612132556_UpdatedSetup")]
    partial class UpdatedSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BooksAPI.Domain.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EditionYear")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "Arthur Golden",
                            Description = "In this literary tour de force, novelist Arthur Golden enters a remote and shimmeringly exotic world. For the protagonist of this peerlessly observant first novel is Sayuri, one of Japan's most celebrated geisha, a woman who is both performer and courtesan, slave and goddess. We follow Sayuri from her childhood in an impoverished fishing village, where in 1929, she is sold to a representative of a geisha house, who is drawn by the child's unusual blue-grey eyes. From there she is taken to Gion, the pleasure district of Kyoto. She is nine years old. In the years that follow, as she works to pay back the price of her purchase, Sayuri will be schooled in music and dance, learn to apply the geisha's elaborate makeup, wear elaborate kimono, and care for a coiffure so fragile that it requires a special pillow.She will also acquire a magnanimous tutor and a venomous rival.Surviving the intrigues of her trade and the upheavals of war, the resourceful Sayuri is a romantic heroine on the order of Jane Eyre and Scarlett O'Hara. And \"Memoirs of a Geisha\" is a triumphant work - suspenseful, and utterly persuasive.",
                            EditionYear = 2005,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9781/4000/9781400096893.jpg",
                            Publisher = "Random House",
                            Title = "Memoirs of a Geisha"
                        },
                        new
                        {
                            BookId = 2,
                            Author = "J.D.Salinger",
                            Description = "The Catcher in Rye is the ultimate novel for disaffected youth, but it's relevant to all ages. The story is told by Holden Caulfield, a seventeen- year-old dropout who has just been kicked out of his fourth school. Throughout, Holden dissects the 'phony' aspects of society, and the 'phonies' themselves: the headmaster whose affability depends on the wealth of the parents, his roommate who scores with girls using sickly-sweet affection.Lazy in style, full of slang and swear words, it's a novel whose interest and appeal comes from its observations rather than its plot intrigues (in conventional terms, there is hardly any plot at all). Salinger's style creates an effect of conversation, it is as though Holden is speaking to you personally, as though you too have seen through the pretences of the American Dream and are growing up unable to see the point of living in, or contributing to, the society around you.Written with the clarity of a boy leaving childhood, it deals with society, love, loss, and expectations without ever falling into the clutch of a cliche.",
                            EditionYear = 2010,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/2419/9780241950425.jpg",
                            Publisher = "Penguin Books",
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            BookId = 3,
                            Author = "Charles Dickens",
                            Description = "'A parish child - the orphan of a workhouse - the humble, half-starved drudge - to be cuffed and buffeted through the world, despised by all, and pitied by none'Dark, mysterious and mordantly funny, Oliver Twist features some of the most memorably drawn villains in all of fiction - the treacherous gangmaster Fagin, the menacing thug Bill Sikes, the Artful Dodger and their den of thieves in the grimy London backstreets. Dicken's novel is both an angry indictment of poverty, and an adventure filled with an air of threat and pervasive evil.",
                            EditionYear = 2012,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1411/9780141198880.jpg",
                            Publisher = "Penguin Books",
                            Title = "Oliver Twist"
                        },
                        new
                        {
                            BookId = 4,
                            Author = "Oscar Wilde",
                            Description = "'I am jealous of everything whose beauty does not die. I am jealous of the portrait you have painted of me ... Why did you paint it? It will mock me some day - mock me horribly!'A story of evil, debauchery and scandal, Oscar Wilde's only novel tells of Dorian Gray, a beautiful yet corrupt man. When he wishes that a perfect portrait of himself would bear the signs of ageing in his place, the picture becomes his hideous secret, as it follows Dorian's own downward spiral into cruelty and depravity. The Picture of Dorian Gray is a masterpiece of the evil in men's hearts, and is as controversial and alluring as Wilde himself.",
                            EditionYear = 2012,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1411/9780141199498.jpg",
                            Publisher = "Penguin Books",
                            Title = "The Picture of Dorian Gray"
                        },
                        new
                        {
                            BookId = 5,
                            Author = "Daniel Keyes",
                            Description = "Winner of both the Hugo and Nebula Awards, the powerful, classic story about a man who receives an operation that turns him into a genius...and introduces him to heartache. Charlie Gordon is about to embark upon an unprecedented journey. Born with an unusually low IQ, he has been chosen as the perfect subject for an experimental surgery that researchers hope will increase his intelligence-a procedure that has already been highly successful when tested on a lab mouse named Algernon. As the treatment takes effect, Charlie's intelligence expands until it surpasses that of the doctors who engineered his metamorphosis. The experiment appears to be a scientific breakthrough of paramount importance, until Algernon suddenly deteriorates. Will the same happen to Charlie?",
                            EditionYear = 2005,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1560/9780156030304.jpg",
                            Publisher = "Mariner Books",
                            Title = "Flowers for Algernon"
                        },
                        new
                        {
                            BookId = 6,
                            Author = "E.Scott Fitzgerald",
                            Description = "'It was one of those rare smiles with a quality of eternal reassurance in it, that you may come across four or five times in life'Jay Gatsby is the man who has everything. But one thing will always be out of his reach ... Everybody who is anybody is seen at his glittering parties. Day and night his Long Island mansion buzzes with bright young things drinking, dancing and debating his mysterious character. For Gatsby - young, handsome, fabulously rich - always seems alone in the crowd, watching and waiting, though no one knows what for. Beneath the shimmering surface of his life he is hiding a secret: a silent longing that can never be fulfilled.And soon this destructive obsession will force his world to unravel.",
                            EditionYear = 2018,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/2413/9780241341469.jpg",
                            Publisher = "Penguin Books",
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            BookId = 7,
                            Author = "Charles Dickens",
                            Description = "Great Expectations, Dickens's funny, frightening and tender portrayal of the orphan Pip's journey of self-discovery, is one of his best-loved works. Showing how a young man's life is transformed by a mysterious series of events - an encounter with an escaped prisoner; a visit to a black-hearted old woman and a beautiful girl; a fortune from a secret donor - Dickens's late novel is a masterpiece of psychological and moral truth, and Pip among his greatest creations.",
                            EditionYear = 2012,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1411/9780141198897.jpg",
                            Publisher = "Penguin Books",
                            Title = "Great Expectations"
                        },
                        new
                        {
                            BookId = 8,
                            Author = "John Steinbek",
                            Description = "California's fertile Salinas Valley is home to two families whose destinies are fruitfully, and fatally, intertwined. Over the generations, between the beginning of the twentieth century and the end of the First World War, the Trasks and the Hamiltons will helplessly replay the fall of Adam and Eve and the murderous rivalry of Cain and Abel.East of Eden was considered by Steinbeck to be his magnum opus, and its epic scope and memorable characters, exploring universal themes of love and identity, ensure it remains one of America's most enduring novels.",
                            EditionYear = 2017,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/2419/9780241980354.jpg",
                            Publisher = "Penguin Books",
                            Title = "East of Eden"
                        },
                        new
                        {
                            BookId = 9,
                            Author = "Thomas Hardy",
                            Description = "When Tess Durbeyfield is driven by family poverty to claim kinship with the wealthy D'Urbervilles and seek a portion of their family fortune, meeting her 'cousin' Alec proves to be her downfall. A very different man, Angel Clare, seems to offer her love and salvation, but Tess must choose whether to reveal her past or remain silent in the hope of a peaceful future. With its sensitive depiction of the wronged Tess and powerful criticism of social convention, Tess of the D'Urbervilles is one of the most moving and poetic of Hardy's novels.",
                            EditionYear = 2012,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1411/9780141199948.jpg",
                            Publisher = "Penguin Books",
                            Title = "Tess of the D'Urbervilles"
                        },
                        new
                        {
                            BookId = 10,
                            Author = "Arthur Conan Doyle",
                            Description = "When Dr John Watson takes rooms in Baker Street with amateur detective Sherlock Holmes, he has no idea that he is about to enter a shadowy world of criminality and violence. Accompanying Holmes to an ill-omened house in south London, Watson is startled to find a dead man whose face is contorted in a rictus of horror. There is no mark of violence on the body yet a single word is written on the wall in blood. Dr Watson is as baffled as the police, but Holmes's brilliant analytical skills soon uncover a trail of murder, revenge and lost love .",
                            EditionYear = 2014,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/mid/9780/1413/9780141395524.jpg",
                            Publisher = "Penguin Books",
                            Title = "A Study in Scarlet"
                        },
                        new
                        {
                            BookId = 11,
                            Author = "Jean Rhys",
                            Description = "If Antoinette Cosway, a spirited Creole heiress, could have foreseen the terrible future that awaited her, she would not have married the young Englishman. Initially drawn to her beauty and sensuality, he becomes increasingly frustrated by his inability to reach into her soul. He forces Antoinette to conform to his rigid Victorian ideals, unaware that in taking away her identity he is destroying a part of himself as well as pushing her towards madness.",
                            EditionYear = 2011,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/2419/9780241951552.jpg",
                            Publisher = "Penguin Books",
                            Title = "Wide Sargasso Sea"
                        },
                        new
                        {
                            BookId = 12,
                            Author = "Fyodor Dostoyevsky",
                            Description = "The murder of brutal landowner Fyodor Karamazov changes the lives of his sons irrevocably: Mitya, the sensualist, whose bitter rivalry with his father immediately places him under suspicion for parricide; Ivan, the intellectual, driven to breakdown; the spiritual Alyosha, who tries to heal the family's rifts; and the shadowy figure of their bastard half-brother, Smerdyakov. Dostoyevsky's dark masterwork evokes a world where the lines between innocence and corruption, good and evil, blur, and everyone's faith in humanity is tested.",
                            EditionYear = 2003,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/1404/9780140449242.jpg",
                            Publisher = "Penguin Books",
                            Title = "The Brothers Karamazov"
                        },
                        new
                        {
                            BookId = 13,
                            Author = "Jane Austen",
                            Description = "During an eventful season at Bath, young, naive Catherine Morland experiences the joys of fashionable society for the first time. She is delighted with her new acquaintances: flirtatious Isabella, who shares Catherine's love of Gothic romance and horror, and sophisticated Henry and Eleanor Tilney, who invite her to their father's mysterious house, Northanger Abbey. There, her imagination influenced by novels of sensation and intrigue, Catherine imagines terrible crimes committed by General Tilney. With its broad comedy and irrepressible heroine, this is the most youthful and and optimistic of Jane Austen's works.",
                            EditionYear = 2012,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/1413/9780141389424.jpg",
                            Publisher = "Penguin Books",
                            Title = "Northanger Abbey"
                        },
                        new
                        {
                            BookId = 14,
                            Author = "F. Scott Fitzgerald",
                            Description = "This Side of Paradise, F. Scott Fitzgerald's romantic and witty first novel, was written when the author was only twenty-three years old. This semiautobiographical story of the handsome, indulged, and idealistic Princeton student Amory Blaine received critical raves and catapulted Fitzgerald to instant fame. Now readers can enjoy the newly edited, authorized version of this early classic of the Jazz Age, based on Fitzgerald's original manuscript. In this definitive text, This Side of Paradise captures the rhythms and romance of Fitzgerald's youth and offers a poignant portrait of the Lost Generation.",
                            EditionYear = 2000,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/4862/9780486289991.jpg",
                            Publisher = "Dover Publications",
                            Title = "This Side of Paradise"
                        },
                        new
                        {
                            BookId = 15,
                            Author = "Patrick Suskind",
                            Description = "In eighteenth-century France there lived a man who was one of the most gifted and abominable personages in an era that knew no lack of gifted and abominable personages. His name was Jean-Baptiste Grenouille, and if his name has been forgotten today, it is certainly not because Grenouille fell short of those more famous blackguards when it came to arrogance, misanthropy, immorality, or, more succinctly, wickedness, but because his gifts and his sole ambition were restricted to a domain that leaves no traces in history: to the fleeting realm of scent . . .",
                            EditionYear = 2010,
                            ImageUrl = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/1410/9780141041155.jpg",
                            Publisher = "Penguin Books",
                            Title = "Perfume: The Story of a Murderer"
                        });
                });

            modelBuilder.Entity("BooksAPI.Domain.LibraryItem", b =>
                {
                    b.Property<int>("LibraryItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LibraryItemId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("LibraryItems");
                });

            modelBuilder.Entity("BooksAPI.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BooksAPI.Domain.LibraryItem", b =>
                {
                    b.HasOne("BooksAPI.Domain.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksAPI.Domain.User", "User")
                        .WithMany("LibraryItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}